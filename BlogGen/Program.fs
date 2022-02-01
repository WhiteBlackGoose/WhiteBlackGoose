﻿open Dsl
open System.IO
open PreviewImage

type Lang = EN | RU

type Article = {
    lang : Lang
    tags : string list
    link : string
    title : string
}

let articles = [
    { lang = EN; tags = [ "C#" ];       title = "This is how Variadic Arguments could work in C#";
        link = "https://whiteblackgoose.medium.com/this-is-how-variadic-arguments-could-work-in-c-e2034a9c241" }
    
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
    header [] [
        link ["rel", "stylesheet"; "type", "text/css"; "href", "https://fonts.googleapis.com/css?family=Overpass+Mono"]
        style [] [
            cssClass "cards" [
                "margin", "0 auto"
                "max-width", "1500px"
                "display", "grid"
                "grid-template-columns", "repeat(2, 1fr)"
                "column-gap", "20px"
                "row-gap", "40px"
                "font-family", "Overpass Mono"
            ]
            cssClass "card" [
                "box-shadow", "0 0 5px rgba(0, 0, 0, 0.1)"
                
            ]
            cssClass "card_title_container" [
                "padding", "20px"
            ]
            cssClass "card_title" [
                
            ]
            cssClass "card_image" [
                "width", "100%"
                "display", "block"
            ]
            cssFilter "a" [
                "color", "black"
                "text-decoration", "none"
            ]
        ]
    ]
    body [] <| seq {
        h1 [] "Blog of WhiteBlackGoose"
        div ["class", "cards"] <| seq {
            for { lang = lang; tags = tags; title = title; link = link } in articles do
                div ["class", "card"] [
                    img ["class", "card_image"] (getPreviewImage link)
                    div ["class", "card_title_container"] [
                        a ["class", "card_title"] link (h3 [] title)
                    ]
                ]
        }
    }
}

Directory.CreateDirectory "blog" |> ignore
File.WriteAllText("blog/index.html", page)
