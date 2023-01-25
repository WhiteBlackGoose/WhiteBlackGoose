module Utils

let useLocally = System.Environment.GetEnvironmentVariable("PROD") = null
let locAwarePath path = if useLocally then System.IO.Path.Combine(path, "index.html") else path
