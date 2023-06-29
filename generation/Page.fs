module Page

open Giraffe.ViewEngine

type Page = {
    title : string
    url : string
    filename : string
    contents : XmlNode list
}

// Regexes
// Bold:
// %s/\*\*\(.\{-}\)\*\*/{bo "\1"}/g
// Italics:
// %s/\*\(.\{-}\)\*/{it "\1"}/g
// Backticks:
// %s/\`\(.\{-}\)\*/{co "\1"}/g
// Links:
// %s/\[\([A-z0-9\s]\{-}\)\](\(.\{-}\))/{ur "\2" "\1"}/g

let bo text = b [] [ Text text ] |> RenderView.AsString.htmlNode
let it text = i [] [ Text text ] |> RenderView.AsString.htmlNode
let ur url name = a [_href url] [ Text name ] |> Giraffe.ViewEngine.RenderView.AsString.htmlNode
let co text = span [_class "code-inline"] [ Text text ] |> Giraffe.ViewEngine.RenderView.AsString.htmlNode
let _a url name = a [_href url] [ Text name ] |> Giraffe.ViewEngine.RenderView.AsString.htmlNode

let anc tag = a [_href $"#{tag}"; _name tag; _style "fill: gray;"; attr "aria-label" $"Jump to header {tag}"] [ Text www.``static``.media.icons.link ]
let refanc tag text = a [_href $"#{tag}"] [ Text text ]

