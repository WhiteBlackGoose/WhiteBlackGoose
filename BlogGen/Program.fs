open System.IO
open PreviewImage
open Giraffe.ViewEngine
open Css

type Lang = EN | RU

type Article = {
    lang : Lang
    tags : string list
    link : string
    title : string
}

let articles = [
    { lang = EN; tags = [ "F#"; "asm" ];  title = "Inline Assembly in F#! How does it work?";
        link = "https://blog.devgenius.io/inline-assembly-in-f-net-language-6d70ab9f58c1" }

    { lang = EN; tags = [ "C#" ];         title = "This is how Variadic Arguments could work in C#";
        link = "https://whiteblackgoose.medium.com/this-is-how-variadic-arguments-could-work-in-c-e2034a9c241" }
    
    { lang = RU; tags = [ "F#"; "C#" ];   title = "Как LINQ, только быстрый и без аллокаций";
        link = "https://habr.com/ru/post/648529";  }
    
    { lang = EN; tags = [ "C#" ];         title = "Like Regular LINQ, but Faster and Without Allocations: Is It Possible?";
        link = "https://whiteblackgoose.medium.com/3d4724632e2a" }
    
    { lang = RU; tags = [ "C#"; "F#" ];   title = "Очень типобезопасно! Концепт продвинутой расширяемой системы единиц измерения с generic math для .NET";
        link = "https://habr.com/ru/post/597437/" }
    
    { lang = EN; tags = [ "C#"; "F#" ];   title = "Stay safe with your units! Advanced units of measure in .NET.";
        link = "https://whiteblackgoose.medium.com/stay-safe-with-your-units-advanced-units-of-measure-in-net-f7d8b02af87e" }
    
    { lang = RU; tags = [ "C#"; "perf" ]; title = "Ускоряем цикл foreach до for";
        link = "https://habr.com/ru/post/575664/" }
    
    { lang = EN; tags = [ "C#"; "perf" ]; title = "Making loop \"foreach\" as fast as \"for\"";
        link = "https://habr.com/en/post/575916/" }
    
    { lang = RU; tags = [ "C#"; "wasm" ]; title = "Хостим WASM-приложения на github pages в два клика";
        link = "https://habr.com/ru/post/566286/" }
    
    { lang = RU; tags = [ "C#" ];         title = "Компилируем математические выражения";
        link = "https://habr.com/ru/post/546622/" }
    
    { lang = EN; tags = [ "C#"; "F#"; "AngouriMath" ]; title = "AngouriMath 1.3 update";
        link = "https://habr.com/en/post/565996/" }
    
    { lang = EN; tags = [ "C#" ];         title = "Compilation of symbolic expressions into Linq.Expression";
        link = "https://habr.com/en/post/546926/" }
    
    { lang = EN; tags = [ "C#"; "oop" ];  title = "Lazy Properties Are Good. That Is How You Are to Use Them";
        link = "https://habr.com/en/post/545936/" }
    
    { lang = EN; tags = [ "F#"; "AngouriMath" ]; title = "AngouriMath for Research with F#";
        link = "https://am.angouri.org/research" }
    
    { lang = EN; tags = [ "C#" ]; title = "Parsing a math expression in C#";
        link = "https://whiteblackgoose.medium.com/parsing-a-math-expression-from-string-in-c-b2b48e2ac2e6" }
    
    { lang = EN; tags = [ ".NET"; "Jupyter" ]; title = "Jupyter in .NET";
        link = "https://habr.com/en/post/528816" }
    
    { lang = RU; tags = [ "C#" ]; title = "Методы без аргументов — зло в ООП, и вот как его полечить";
        link = "https://habr.com/ru/post/529454/" }
    
    { lang = RU; tags = [ ".NET"; "Jupyter" ]; title = "Jupyter для .NET. «Как в питоне»";
        link = "https://habr.com/ru/post/528730/" }

    { lang = RU; tags = [ "C#"; "F#" ]; title = "Что нового в AngouriMath 1.2?";
        link = "https://habr.com/en/post/545190/" }

    { lang = EN; tags = [ "C#"; "F#" ]; title = "What's new in AngouriMath 1.2?";
        link = "https://habr.com/en/post/545436" }
    
    { lang = RU; tags = [ "C#"; "perf" ]; title = "Тензоры для C#. И матрицы, и векторы, и кастомный тип, и сравнительно быстро";
        link = "https://habr.com/ru/post/512856/" }
    
    { lang = EN; tags = [ "C#"; "perf" ]; title = "Generic tensors in C#";
        link = "https://gist.github.com/WhiteBlackGoose/5b84b2237704a91ffe7f34372196df32" }

    { lang = EN; tags = [ "C#" ]; title = "Symbolic algrebra in C#";
        link = "https://habr.com/en/post/486496" }
    
    { lang = RU; tags = [ "C#" ]; title = "Пишем «калькулятор». Часть II. Решаем уравнения, рендерим в LaTeX, ускоряем функции до сверхсветовой";
        link = "https://habr.com/ru/post/483294/" }
    
    { lang = RU; tags = [ "C#" ]; title = "Пишем «калькулятор» на C#. Часть I. Вычисление значения, производная, упрощение, и другие гуси";
        link = "https://habr.com/ru/post/482228/" }
    
    { lang = EN; tags = [ "python" ]; title = "Simple simulation of custom physical interactions with particles";
        link = "https://dzone.com/articles/a-simple-simulation-of-custom-physical-interaction" }
    
    { lang = RU; tags = [ "python" ]; title = "Элементарная симуляция кастомного физического взаимодействия на python + matplotlib";
        link = "https://habr.com/ru/post/467803/" }
    
    { lang = EN; tags = [ "python" ]; title = "Yet another snake with Kivy, Python";
        link = "https://habr.com/en/post/465523" }
    
    { lang = RU; tags = [ "python" ]; title = "Играемся с комплексными числами";
        link = "https://habr.com/ru/post/468781/" }
    
    { lang = RU; tags = [ "python" ]; title = "Генератор простых арифметических примеров для чайников и не только";
        link = "https://habr.com/ru/post/468457/" }
    
]

// let auto src = a [] $"https://{src}" src

let page = html [] [
    title [] [ Text "WhiteBlackGoose' blog" ]
    head [] [
        link [_rel "icon"; _type "image/png"; _href "https://avatars.githubusercontent.com/u/31178401"]
        link [_rel "stylesheet"; _type "text/css"; _href "https://fonts.googleapis.com/css?family=Overpass+Mono"]
        makeStyle [] [
            lightTheme [
                cssFilter "body" [
                    "background", "rgb(230, 230, 230)"
                    "color", "#333"
                ]
                cssClass "card" [
                    "box-shadow", "0 0 15px rgba(0, 0, 0, 0.1)"
                    "background", "white"
                ]
                cssClass "tags" [
                    "color", "gray"
                ]
                cssFilter "a" [
                    "color", "#333"
                ]
            ]
            darkTheme [
                cssFilter "body" [
                    "background", "rgb(30, 30, 30)"
                    "color", "#BBB"
                ]
                cssClass "card" [
                    "box-shadow", "0 0 15px rgba(0, 0, 0, 0.1)"
                    "background", "#333"
                ]
                cssClass "tags" [
                    "color", "gray"
                ]
                cssFilter "a" [
                    "color", "#BBB"
                ]
            ]
            cssFilter ".header h1" [
                "margin", "0 auto"
            ]
            cssClass "cards" [
                "margin", "0 auto"
                "column-gap", "25px"
                "font-family", "Overpass Mono"
                "line-height", "1.8"
                "column-count", "4"
            ]
            tabletDevice [
                cssClass "cards" [
                    "column-count", "3"
                ]
            ]
            phoneDevice [
                cssClass "cards" [
                    "column-count", "1"
                ]
            ]
            cssClass "card" [
                "margin-top", "25px"
                "min-width", "100%"
                "display", "inline-block"
            ]
            cssClass "card_title_container" [
                "padding", "20px"
            ]
            cssClass "card_title" [
                "text-decoration", "none"
            ]
            cssClass "card_image" [
                "width", "100%"
                "display", "block"
            ]
            cssFilter "a" [
                "text-decoration-line", "underline"
                "text-decoration-style", "solid"
                "text-decoration-color", "gray"
            ]
            
        ]
    ]
    body [] [
        div [_class "cards"] [
            div [inplaceStyle ["padding", "20px"]] [
                h1 [] [ Text "Blog of WhiteBlackGoose" ]
                span [] [
                    p [] [ Text """
                        Hi. I'm WhiteBlackGoose. I write articles about F#, C#, .NET (and sometimes other things).
                        """ ]
                    p [] [
                        Text $"""With the same username you can find me on """
                        a [_href "https://github.com/WhiteBlackGoose"] [ Text "github" ]
                        Text ", "
                        a [_href "https://twitter.com/WhiteBlackGoose"] [ Text "twitter" ]
                        Text ", "
                        a [_href "https://whiteblackgoose.medium.com"]  [ Text "medium" ]
                        Text ", "
                        a [_href "https://reddit.com/u/WhiteBlackGoose"] [ Text "reddit" ]
                        Text "."
                    ]
                    p [] [ 
                        Text "This website is made via F#'s "
                        a [_href "https://github.com/giraffe-fsharp/Giraffe.ViewEngine"] [ Text "Giraffe.ViewEngine" ]
                        Text "."
                    ]

                    p [] [ a [ _href "wbg.angouri.org" ] [ Text "wbg.angouri.org" ] ]
                ]
            ]
            for { tags = tags; title = title; link = link } in articles |> Seq.filter (fun c -> match c.lang with RU -> false | EN -> true ) do
                div [_class "card"] [
                    a [_href link] [img [_class "card_image"; _src (getPreviewImage link)]]
                    div [_class "card_title_container"] [
                        a [_class "card_title"; _href link] [h3 [] [ Text title ]]
                        span [_class "tags"] [
                            Text "Tags: "
                            Text (tags |> String.concat ", ")
                        ]
                    ]
                ]   
        ]
        div [_class "cards"; inplaceStyle ["margin-top", "60px"]] [
            div [inplaceStyle ["padding", "20px"]] [
                h1 [] [ Text "А здесь статьи на русском" ]
                span [] [
                    p [] [
                        Text $"""В рунете меня можно найти еще на двух ресурсах: """
                        a [_href "https://habr.com/users/WhiteBlackGoose/"] [ Text "habr" ]
                        Text ", "
                        a [_href "https://pikabu.ru/@WhiteBlackGoose"] [ Text "pikabu" ]
                        Text ". И в чате @pro.net в телеграме."
                    ]
                ]
            ]
            for { tags = tags; title = title; link = link } in articles |> Seq.filter (fun c -> match c.lang with RU -> true | EN -> false ) do
                div [_class "card"] [
                    a [_href link] [img [_class "card_image"; _src (getPreviewImage link)]]
                    div [_class "card_title_container"] [
                        a [_class "card_title"; _href link] [h3 [] [ Text title ]]
                        span [_class "tags"] [
                            Text "Tags: "
                            Text (tags |> String.concat ", ")
                        ]
                    ]
                ]
        ]
    ]
]


Directory.CreateDirectory "blog" |> ignore

let path = "blog/index.html"

printfn $"Writing to {Path.GetFullPath(path)}"
File.WriteAllText(path, page |> RenderView.AsString.htmlNode)

printfn $"Done. {List.length articles}"
