module www.blog.ux3402za_review.index

open Giraffe.ViewEngine
open Page

let html = PageWrap.wrap www.``static``.styles.css {
 title = "UX3402ZA review"
 url = "blog/ux3402za-review"
 filename = "index.html"
 contents = [
  p [] [
   Text $"""
   Bought this laptop not so long ago and am writing a review (this text might be modified later).
   """
  ]
  br []
  hr []
  br []

  h2 [] [ anc "usecase"; Text $"""Use case""" ]
  p [] [
   Text $"""
   I use {_a (Utils.locAwarePath www.blog.nixos.index.html.url) "NixOS"} with {_a "https://i3wm.org/" "i3"}. Most of the time I edit texts in nvim, view PDFs, and surf the internet (so, no games or video editing or other super-heavy stuff).
   """
  ]

  h2 [] [ anc ""; Text "" ]
 ]
}
