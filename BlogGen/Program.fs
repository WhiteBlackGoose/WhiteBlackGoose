open System.IO
open Giraffe.ViewEngine
open Articles
open Pages

Directory.CreateDirectory "blog" |> ignore
Directory.CreateDirectory "projects" |> ignore

let rootPath = "./blog"

for { page = page; name = name } in pages do
    let path = Path.Combine(rootPath, name, "index.html")
    let html = View.genPage page |> RenderView.AsString.htmlNode
    printfn $"Writing to {Path.GetFullPath(path)}"
    Directory.CreateDirectory (Path.GetDirectoryName path) |> ignore
    printfn $"Length: {html.Length}"
    File.WriteAllText(path, html)
    printfn $"Ok.\n"


printfn $"Finished."
