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
            
        ]
    ]

let octiButton url actionVerb action oci = 
    a [
        _class "github-button"
        _href $"url/{action}"
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
                        h1 [] [ Text "Blog of WhiteBlackGoose" ]
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
                        | Project { name = name; url = url; lang = lang; date = date; } ->
                            div [_class "card"] [
                                a [_href url] [img [_class "card_image"; _src (getPreviewImage url)]]
                                div [_class "card_title_container"] [
                                    span [_class "tags"] [ Text date ]
                                    a [_class "card_title"; _href url] [h3 [] [ Text name ]]
                                    span [] [
                                        octiButton url "Star" "" "star"
                                        octiButton url "Watch" "subscription" "eye"
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
            body [inplaceStyle [ "max_width", "1000px" ]] [
                h1 [] [ Text pageTitle ]
                yield! contents
            ]
        ]
