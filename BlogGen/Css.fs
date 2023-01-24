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


let iconLink = """<svg class="octicon octicon-link" viewBox="0 0 16 16" version="1.1" width="16" height="16" aria-hidden="true"><path fill-rule="evenodd" d="M7.775 3.275a.75.75 0 001.06 1.06l1.25-1.25a2 2 0 112.83 2.83l-2.5 2.5a2 2 0 01-2.83 0 .75.75 0 00-1.06 1.06 3.5 3.5 0 004.95 0l2.5-2.5a3.5 3.5 0 00-4.95-4.95l-1.25 1.25zm-4.69 9.64a2 2 0 010-2.83l2.5-2.5a2 2 0 012.83 0 .75.75 0 001.06-1.06 3.5 3.5 0 00-4.95 0l-2.5 2.5a3.5 3.5 0 004.95 4.95l1.25-1.25a.75.75 0 00-1.06-1.06l-1.25 1.25a2 2 0 01-2.83 0z"></path></svg>"""