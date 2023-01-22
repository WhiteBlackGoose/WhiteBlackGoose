module View

open Css
open PreviewImage
open Pages
open Giraffe.ViewEngine
open Articles

[<RequireQualifiedAccess>]
type Media =
    | Image of string
    | Text of string

let commonHead font = 
    head [] [
        link [_rel "icon"; _type "image/png"; _href "https://avatars.githubusercontent.com/u/31178401"]
        link [_rel "stylesheet"; _type "text/css"; _href "https://fonts.googleapis.com/css?family=Overpass+Mono"]
        link [_rel "stylesheet"; _type "text/css"; _href "https://fonts.googleapis.com/css?family=Ubuntu+Mono"]
        script [_src "https://buttons.github.io/buttons.js"] []
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
                "font-family", font
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
            cssClass "article-body" [
                "font-family", "Overpass Mono"
                "padding", "60px"
                "padding-left", "100px"
                "padding-right", "100px"
                "line-height", "1.7"
            ]
            cssFilter "hr" [
                "width", "20%"
                "background-color", "gray"
                "border", "0.5px solid gray"
            ]
        ]
    ]

let octiButton url actionVerb action oci = 
    a [
        _class "github-button"
        _href $"{url}/{action}"
        _data "color-scheme" "no-preference: dark; light: light; dark: dark;"
        _data "icon" $"icon-{oci}"
        _data "size" "large"
        _data "show-count" "true"
        _data "aria-label" $"{actionVerb} {url} on github"
    ] [ Text actionVerb ]

let genPage contents = function
    | FilterPage { contentFilter = contentFilter; description = description; title = pageTitle } ->
        html [] [
            title [] [ Text pageTitle ]
            commonHead "Ubuntu Mono"
            body [] [
                div [_class "cards"] [
                    div [inplaceStyle ["padding", "20px"]] [
                        h1 [] [ Text "WhiteBlackGoose webpage" ]
                        span [] description
                    ]
                    for content in contents |> Seq.filter contentFilter do
                        match content with
                        | Article { tags = tags; title = title; link = link; date = date } ->
                            div [_class "card"] [
                                a [_href link] [img [_class "card_image"; _src (getPreviewImage link)]]
                                div [_class "card_title_container"] [
                                    span [_class "tags"] [ Text date ]
                                    a [_class "card_title"; _href link] [h3 [] [ Text title ]]
                                    span [_class "tags"] [
                                        Text "Tags: "
                                        Text (tags |> String.concat ", ")
                                    ]
                                ]
                            ]   
                        | Project { name = name; url = url; langs = langs; date = date; } ->
                            div [_class "card"] [
                                a [_href url] [img [_class "card_image"; _src (getPreviewImage url)]]
                                div [_class "card_title_container"] [
                                    span [_class "tags"] [ 
                                        Text date
                                        Text " "
                                        for lang in langs do
                                            let (color, name) =
                                                match lang with
                                                | Projects.ProgrammingLanguage.CSharp -> ("#178600", "C#")
                                                | Projects.ProgrammingLanguage.FSharp -> ("#b845fc", "F#")
                                                | Projects.ProgrammingLanguage.FStar  -> ("#572e30", "F*")
                                                | Projects.ProgrammingLanguage.Bash   -> ("#89e051", "Sh")
                                                | Projects.ProgrammingLanguage.Rust   -> ("#dea584", "Rs")
                                            span [
                                                _style $"""
                                                background-color: {color};
                                                position: relative;
                                                top: 1px;
                                                display: inline-block;
                                                width: 12px;
                                                height: 12px;
                                                border: 1px solid var(--color-primer-border-contrast);
                                                border-radius: 50%%;
                                                """
                                            ] []
                                            Text " "
                                            Text name
                                            Text " "
                                            
                                    ]
                                    a [_class "card_title"; _href url] [h3 [] [ Text name ]]
                                    div [_style "text-align: center;"] [
                                        octiButton url "Star" "" "star"
                                        Text "\n"
                                        octiButton url "Watch" "subscription" "eye"
                                        Text "\n"
                                        octiButton url "Fork" "fork" "forked"
                                    ]
                                ]
                            ]   
                ]
            ]
        ]
    | TextPage { title = pageTitle; contents = contents } ->
        html [] [
            title [] [ Text pageTitle ]
            commonHead "sans-seriff"
            body [_class "article-body"] [
                h1 [] [ Text pageTitle ]
                yield! contents
            ]
        ]
