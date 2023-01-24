open System.IO
open Giraffe.ViewEngine

let rootDir = "out"

let pages = [
    www.blog.what_the_world_could_be_like.index.html
    www.blog.yyyy_mm_dd.index.html
    www.blog.my_values.index.html
    www.blog.pass.index.html
    www.blog.index.html
    www.projects.index.html
    www.index.html
]

for page in pages do
    Directory.CreateDirectory(rootDir </> page.url) |> ignore
    File.WriteAllText(
        rootDir </> page.url </> page.filename,
        RenderView.AsString.htmlNode page)
    printfn $"Generated page {page.url}"
printfn $"Finished."
