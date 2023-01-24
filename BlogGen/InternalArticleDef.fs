module InternalArticleDef

open Giraffe.ViewEngine

type TextPage = {
    title : string
    contents : XmlNode list
}

// thought of making ** and __ preprocessor
// let md = 
//     let bold = System.Text.RegularExpressions.Regex(@"\*\*(.*?)\*\*")
//     let italics = System.Text.RegularExpressions.Regex(@"__(.*?)__")
//     fun text ->
//         text
//         |> bold.Repla

let bo text = b [] [ Text text ] |> RenderView.AsString.htmlNode
let it text = i [] [ Text text ] |> RenderView.AsString.htmlNode
let ur url name = a [_href url] [ Text name ] |> Giraffe.ViewEngine.RenderView.AsString.htmlNode

let anc tag = a [_href $"#{tag}"; _name tag] [ Text ">" ]
let refanc tag text = a [_href $"#{tag}"] [ Text text ]

