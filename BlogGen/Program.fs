open Dsl
open TagListBuilder

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

// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"

let page = html [] <| seq {
    title [] "WhiteBlackGoose' blog"
    header [] []
    yield! seq {
        for { lang = lang; tags = tags; title = title; link = link } in articles do
            div [style ["width", "30%"; "padding", "10px"; "border", "solid 1px gray"]] [
                h3 [] title
            ]
    }
}