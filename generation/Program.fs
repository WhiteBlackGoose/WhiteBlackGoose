open System.IO
open Giraffe.ViewEngine

open Page

let rec ensureExists srcDir dstDir =
    if Directory.Exists(dstDir) |> not then
        Directory.CreateDirectory(dstDir) |> ignore
    for dir in Directory.GetDirectories(srcDir) do
        ensureExists dir (dstDir </> Path.GetFileName dir)
    for file in Directory.GetFiles srcDir do
        File.Copy(file, dstDir </> Path.GetFileName file)

let rootDir = "out"
let sourceDir = "www"

let pages = [
    www.blog.what_the_world_could_be_like.index.html
    www.blog.yyyy_mm_dd.index.html
    www.blog.my_values.index.html
    www.blog.pass.index.html
    www.blog.index.html
    www.gpg.index.html
    www.gpg.pubkey.txt
    www.projects.index.html
    www.index.html
    www.README.html
]

for page in pages do
    Directory.CreateDirectory(rootDir </> page.url) |> ignore
    File.WriteAllText(
        rootDir </> page.url </> page.filename,
        RenderView.AsString.htmlNode page.contents)
    printfn $"Generated page {page.url}"

if Directory.Exists(rootDir </> "static" </> "media") then
    Directory.Delete(rootDir </> "static" </> "media", true)
ensureExists(sourceDir </> "static" </> "media") (rootDir </> "static" </> "media")

printfn $"Finished."
