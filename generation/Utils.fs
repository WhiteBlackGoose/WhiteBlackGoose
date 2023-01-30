module Utils

let useLocally = System.Environment.GetEnvironmentVariable("PROD") = null
let locAwarePath elev path = 
    if useLocally then
        System.IO.Path.Combine(elev, path, "index.html") 
    else 
        System.IO.Path.Combine(elev, path) 
