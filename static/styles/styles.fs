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



let css : XmlNode list = [
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
   cssClass "inv" [
    "filter", "invert(100%)"
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
   "text-decoration-style", "dotted"
   "text-decoration-color", "gray"
  ]
  cssClass "article-body" [
   "font-family", "'FantasqueSansMonoRegular'"
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
  cssFilter "code" [
   "background-color", "#3F3F3F"
   "padding", "4px"
   "border-radius", "3px"
   "color", "white"
   "display", "block"
  ]
  cssFilter ".noborder-table table,tr,td" [
   "border", "none"
  ]
  cssFilter ".noborder-table tr" [
   "line-height", "29px"
  ]
  cssFilter ".noborder-table td" [
   "padding-right", "10px"
  ]
  cssClass "tool-grid" [
   "display", "grid"
   "grid-template-columns", "repeat(auto-fill, minmax(220px, 1fr))"
   "gap", "16px"
   "margin", "20px 0"
  ]
  cssClass "tool-card" [
   "display", "block"
   "border", "1px solid gray"
   "border-radius", "10px"
   "padding", "14px 16px"
   "text-decoration", "none"
   "transition", "transform 0.15s ease, box-shadow 0.15s ease"
  ]
  cssClass "tool-card:hover" [
   "transform", "translateY(-3px)"
   "box-shadow", "0 6px 16px rgba(0, 0, 0, 0.2)"
  ]
  cssClass "tool-card .tool-name" [
   "display", "block"
   "font-weight", "bold"
   "font-size", "1.1em"
  ]
  cssClass "tool-card .tool-domain" [
   "display", "block"
   "font-family", "mono"
   "font-size", "0.8em"
   "color", "gray"
   "margin-top", "2px"
  ]
  cssClass "tool-card .tool-desc" [
   "display", "block"
   "font-size", "0.85em"
   "margin-top", "8px"
   "line-height", "1.4"
  ]
  cssClass "tool-badge" [
   "display", "inline-block"
   "font-size", "0.7em"
   "border", "1px solid gray"
   "border-radius", "6px"
   "padding", "1px 6px"
   "margin-top", "8px"
   "color", "gray"
  ]
 ]
]
