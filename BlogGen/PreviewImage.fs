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
    let magicString = "property=\"og:image\" content=\""
    let index = html.IndexOf magicString + magicString.Length
    let lastIndex = html.IndexOf("\"", index)
    if index = -1 || lastIndex = -1 then
        None
    else
        let res = html[index .. lastIndex - 1]
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
            cache[link] <- "Not found!"
            setCache cache
            "Not found!"