module PreviewImage

open System.IO
open System.Text.Json
open System.Collections.Generic
open FSharp.Data
open System.Xml.Linq

let private cachePath = "./previewcache"

let private getCache () =
    if File.Exists cachePath then
        JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText cachePath)
    else
        Dictionary<_, _> ()

let private setCache cache =
    File.WriteAllText(cachePath, JsonSerializer.Serialize cache)

let private getPreviewImageActive link : string Option =
    let html = Http.RequestString link
    let xmlDoc = XDocument.Load html
    
    let rec findOgImage (node : XElement) =
        let goOverChildren (node : XElement) =
            node.Descendants ()
                |> Seq.map findOgImage
                |> Seq.choose id
                |> Seq.tryHead

        if node.Name.LocalName = "meta" then
            let isOgImage =
                node.Attributes "property"
                |> Seq.exists (fun c -> c.Value = "og:image")
            if isOgImage then
                node.Attributes "content"
                |> Seq.map (fun c -> c.Value)
                |> Seq.tryHead
            else
                goOverChildren node
        else
            goOverChildren node
    
    findOgImage xmlDoc.Root

let getPreviewImage link =
    let cache = getCache ()
    match cache.TryGetValue link with
    | (true, url) -> url
    | (false, _) ->
        match getPreviewImageActive link with
        | Some url ->
            cache[link] <- url
            setCache cache
            url
        | None ->
            cache[link] <- "Not found!"
            setCache cache
            "Not found!"