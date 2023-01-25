module PageWrap

open Giraffe.ViewEngine
open Page

type WrappedPage = {
    url : string
    filename : string
    contents : XmlNode
    title : string
}

let wrap css ({ title = pageTitle; url = url; filename = filename; contents = contents } : Page) : WrappedPage = 
    { url = url
      filename = filename
      title = pageTitle
      contents = 
        let _a url name = a [_href url] [ Text name ] |> Giraffe.ViewEngine.RenderView.AsString.htmlNode
        html [] [
            title [] [ Text pageTitle ]
            head [] [
                link [_rel "icon"; _type "image/png"; _href "https://avatars.githubusercontent.com/u/31178401"]
                link [_rel "stylesheet"; _type "text/css"; _href "https://fonts.googleapis.com/css?family=Overpass+Mono"]
                link [_rel "stylesheet"; _type "text/css"; _href "https://fonts.googleapis.com/css?family=Ubuntu+Mono"]
                css
            ]
            body [] [
                let sp = span [_style "color: gray;"] [ Text "|" ] |> RenderView.AsString.htmlNode
                let comp f = f [_style "padding: 12px; color: gray;"] [
                    let navig = 
                        if url = "." then 
                            ""
                        else
                            let elevationCount = url |> String.filter ((=) '/') |> String.length
                            let elevation = 
                                [ for _ in 1 .. elevationCount + 1 do "../" ] |> String.concat ""
                            let homePath = Utils.locAwarePath elevation
                            let upPath = Utils.locAwarePath ".."
                            $"""{_a homePath "Home"} {sp} {_a upPath "Up"} {sp}"""
                            
                    Text $"""Blog of WhiteBlackGoose {sp} {navig} This website is {_a "https://github.com/WhiteBlackGoose/WhiteBlackGoose/tree/master/BlogGen" "free software"} (GPLv3) {sp} The {_a "https://github.com/WhiteBlackGoose/WhiteBlackGoose/tree/master/BlogGen/Contents/InternalArticles" "content"} is under CC BY-NC 4.0"""
                ]
                comp header
                div [_class "article-body"] [
                h1 [] [ Text pageTitle ]
                yield! contents
                ]
                comp footer
            ]
        ]
    }
