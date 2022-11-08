open System.IO
open Giraffe.ViewEngine
open Articles
open Projects
open Pages

Directory.CreateDirectory "blog" |> ignore
Directory.CreateDirectory "projects" |> ignore

let contents =
   let cs : Content list = (articles |> List.map (fun a -> Content.Article a)) @ (projects |> List.map (fun b -> Content.Project b))
   cs |> List.sortBy dateOfContent

let burnInto rootPath (pages : PageInfo list) =
    for { page = page; name = name } in pages do
        let path = Path.Combine(rootPath, name, "index.html")
        let html = View.genPage contents page |> RenderView.AsString.htmlNode
        printfn $"Writing to {Path.GetFullPath(path)}"
        Directory.CreateDirectory (Path.GetDirectoryName path) |> ignore
        printfn $"Length: {html.Length}"
        File.WriteAllText(path, html)
        printfn $"Ok.\n"

burnInto "./blog" articlePages
burnInto "./projects" projectPages

printfn $"Finished."
