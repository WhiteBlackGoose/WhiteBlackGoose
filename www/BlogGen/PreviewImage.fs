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
    let options = JsonSerializerOptions()
    options.WriteIndented <- true
    File.WriteAllText(cachePath, JsonSerializer.Serialize(cache, options))

let private getPreviewImageActive link : string Option =
    let html = Http.RequestString link
    let magicString = "property=\"og:image\" content=\""
    let index = html.IndexOf magicString
    if index = -1 then
        None
    else
        let start = index + magicString.Length
        let lastIndex = html.IndexOf("\"", start)
        if lastIndex = -1 then
            None
        else
            let res = html[start .. lastIndex - 1]
            res |> Some


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
            cache[link] <- "https://user-images.githubusercontent.com/31178401/135977941-f15f2ca1-dc29-46e1-93ef-929ee0467f00.jpg"
            setCache cache
            "https://user-images.githubusercontent.com/31178401/135977941-f15f2ca1-dc29-46e1-93ef-929ee0467f00.jpg"