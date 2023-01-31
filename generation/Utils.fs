module Utils

let (</>) p1 p2 = System.IO.Path.Combine(p1, p2)

let useLocally = System.Environment.GetEnvironmentVariable("PROD") = null

let currDir = System.Environment.CurrentDirectory
let sourceRoot = currDir </> "out"
let targetRoot = 
    if useLocally then
        sourceRoot
    else
        "/"

let fixUrlEnding (path : string) =
    if useLocally && not (System.IO.Path.HasExtension path) then
        path </> "index.html"
    else 
        path

let locAwarePath path = fixUrlEnding (targetRoot </> path)
