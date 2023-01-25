module www.``static``.styles

open Giraffe.ViewEngine

type Attributes = (string * string) seq

let inplaceStyle (attrs : Attributes) =
    let inner =
        attrs
        |> Seq.map (fun (a, b) -> $"{a}: {b};")
        |> String.concat ""
    attr "style" $"{inner}"

let cssFilter filter attrs =
    let inner =
        attrs
        |> Seq.map (fun (a, b) -> $"{a}: {b};")
        |> String.concat "\n"
    $"{filter} {{\n{inner}\n}}\n"

let cssClass name attrs = cssFilter $".{name}" attrs

let theme themeName attrs =
    let inner = attrs |> String.concat ""
    $"@media (prefers-color-scheme: {themeName}) {{\n{inner}\n}}"

let sizeNoBiggerThan size attrs =
    let inner = attrs |> String.concat ""
    $"@media only screen and (max-width: {size}px) {{\n{inner}\n}}"

let lightTheme attrs = theme "light" attrs

let darkTheme attrs = theme "dark" attrs

let phoneDevice attrs = sizeNoBiggerThan 1000 attrs

let tabletDevice attrs = sizeNoBiggerThan 1600 attrs

let makeStyle attrs (contents : seq<string>) =
    style attrs [ contents |> String.concat "" |> Text ]



let css : XmlNode = 
    makeStyle [] [
        lightTheme [
            cssFilter "body" [
                "background", "rgb(230, 230, 230)"
                "color", "#333"
            ]
            cssFilter "a" [
                "color", "#333"
            ]
            cssClass "code-inline" [
                "background", "lightgray"
            ]
        ]
        darkTheme [
            cssFilter "body" [
                "background", "rgb(30, 30, 30)"
                "color", "#BBB"
            ]
            cssFilter "a" [
                "color", "#BBB"
            ]
            cssClass "code-inline" [
                "background", "#333"
            ]
        ]
        cssClass "code-inline" [
            "font-family", "mono"
            "padding", "2px"
            "border-radius", "4px"
        ]
        cssFilter ".header h1" [
            "margin", "0 auto"
        ]
        cssFilter "a" [
            "text-decoration-line", "underline"
            "text-decoration-style", "solid"
            "text-decoration-color", "gray"
        ]
        cssClass "article-body" [
            "font-family", "Overpass Mono"
            "padding", "60px"
            "padding-left", "20%"
            "padding-right", "20%"
            "line-height", "1.7"
        ]
        cssFilter "hr" [
            "width", "20%"
            "background-color", "gray"
            "border", "0.5px solid gray"
        ]
    ]
