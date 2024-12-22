module www.blog.neovim.index

open Giraffe.ViewEngine
open Page
open System.IO
open Utils

let refancs anc text =
    refanc anc text |> RenderView.AsString.htmlNode

let html = PageWrap.wrap www.``static``.styles.css {
 title = "Gallery of Neovim"
 url = "blog/neovim"
 filename = "index.html"
 contents = [
  p [_style "text-align: center"] [
   Text "🚧 WIP 🚧"
  ]
  p [] [
   Text $"""
   Neovim is my favourite text/code/everything editor. I've been using it for a few years now, and I've never looked back. I'm lazy to write a full review, so here's a gallery.
   """
  ]
  br []
  hr []
  br []
  h2 [] [ Text "Gallery" ]
  for webm in Directory.GetFiles("www/static/media/neovim") do
    h2 [] [ anc (Path.GetFileName webm); Text $"""{Path.GetFileName webm}"""]
    video [ _style "width: 100%"; attr "autoplay" "false"; attr "controls" "true"; attr "loop" "true" ] [
     source [_src (Utils.locAwarePath ("static/media/neovim/" </> Path.GetFileName webm)); _type "video/webm"]
     Text "Your browser does not support the video tag."
    ]
 ]
}
