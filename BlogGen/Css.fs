module Css

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