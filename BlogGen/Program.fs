open System.IO
open Giraffe.ViewEngine
open Articles
open Pages

Directory.CreateDirectory "blog" |> ignore
Directory.CreateDirectory "projects" |> ignore

// let contents =
//    List.concat (articles :> List<IDated>) (projects :> List<IDated>)
//    |> List.sort (fun d -> d.date)

let burnInto rootPath pages =
    for { page = page; name = name } in pages do
        let path = Path.Combine(rootPath, name, "index.html")
        let html = View.genPage page |> RenderView.AsString.htmlNode
        printfn $"Writing to {Path.GetFullPath(path)}"
        Directory.CreateDirectory (Path.GetDirectoryName path) |> ignore
        printfn $"Length: {html.Length}"
        File.WriteAllText(path, html)
        printfn $"Ok.\n"

burnInto "./blog" articlePages
burnInto "./projects" projectPages

printfn $"Finished."
