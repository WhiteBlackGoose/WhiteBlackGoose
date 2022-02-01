open Dsl
open System.IO

type Lang = EN | RU

type Article = {
    lang : Lang
    tags : string list
    link : string
    title : string
}



let articles = [
    { lang = EN; tags = [ "C#" ];       title = "This is how Variadic Arguments could work in C#";
        link = "(https://whiteblackgoose.medium.com/this-is-how-variadic-arguments-could-work-in-c-e2034a9c241" }
    
    { lang = RU; tags = [ "F#"; "C#" ]; title = "Как LINQ, только быстрый и без аллокаций";
        link = "https://habr.com/ru/post/648529";  }
    
    { lang = EN; tags = [ "C#" ];       title = "Like Regular LINQ, but Faster and Without Allocations: Is It Possible?";
        link = "https://whiteblackgoose.medium.com/3d4724632e2a" }
    
    { lang = RU; tags = [ "C#"; "F#" ]; title = "Очень типобезопасно! Концепт продвинутой расширяемой системы единиц измерения с generic math для .NET";
        link = "https://habr.com/ru/post/597437/" }
    
    { lang = EN; tags = [ "C#"; "F#" ]; title = "Stay safe with your units! Advanced units of measure in .NET.";
        link = "https://whiteblackgoose.medium.com/stay-safe-with-your-units-advanced-units-of-measure-in-net-f7d8b02af87e" }
]


let page = html [] <| seq {
    title [] "WhiteBlackGoose' blog"
    header [] []
    body [] <| seq {
        div [style ["width", "60%"; "margin", "20%"; "display", "grid"; "grid-template-columns", "30% 30% 30%"]] <| seq {
            yield! seq {
                for { lang = lang; tags = tags; title = title; link = link } in articles do
                    div [style ["padding", "10px"; "margin", "20px"; "border", "solid 1px lightgray"]] [
                        a [] link (h3 [] title)
                    ]
            }
        }
    }
}

Directory.CreateDirectory "blog" |> ignore
File.WriteAllText("blog/index.html", page)
