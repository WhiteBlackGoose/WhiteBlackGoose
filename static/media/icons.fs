module www.``static``.media.icons

open Giraffe.ViewEngine

let link = """<svg class="octicon octicon-link" viewBox="0 0 16 16" version="1.1" width="16" height="16" aria-hidden="true"><path fill-rule="evenodd" d="M7.775 3.275a.75.75 0 001.06 1.06l1.25-1.25a2 2 0 112.83 2.83l-2.5 2.5a2 2 0 01-2.83 0 .75.75 0 00-1.06 1.06 3.5 3.5 0 004.95 0l2.5-2.5a3.5 3.5 0 00-4.95-4.95l-1.25 1.25zm-4.69 9.64a2 2 0 010-2.83l2.5-2.5a2 2 0 012.83 0 .75.75 0 001.06-1.06 3.5 3.5 0 00-4.95 0l-2.5 2.5a3.5 3.5 0 004.95 4.95l1.25-1.25a.75.75 0 00-1.06-1.06l-1.25 1.25a2 2 0 01-2.83 0z"></path></svg>"""

let logoSize = "60"

let NixOS = img [_src "https://raw.githubusercontent.com/NixOS/nixos-artwork/c1dc75611042b57a385c80495d3728724c35cfee/logo/nix-snowflake.svg"; _width logoSize; _height logoSize ]
let NeoVim elev = img [_src (System.IO.Path.Combine(elev, "static/media/neovim.png")); _width logoSize; _height logoSize]
let FSharp = img [_src "https://cdn.svgporn.com/logos/fsharp.svg?response-content-disposition=attachment%3Bfilename%3Dfsharp.svg"; _width logoSize; _height logoSize]
let CSharp = img [_src "https://cdn.svgporn.com/logos/c-sharp.svg?response-content-disposition=attachment%3Bfilename%3Dc-sharp.svg"; _width logoSize; _height logoSize]
let git = img [_src "https://cdn.svgporn.com/logos/git-icon.svg?response-content-disposition=attachment%3Bfilename%3Dgit-icon.svg"; _width logoSize; _height logoSize]
let GNU = img [_src "https://cdn.svgporn.com/logos/gnu.svg?response-content-disposition=attachment%3Bfilename%3Dgnu.svg"; _width logoSize; _height logoSize]
let bitcoin = img [_src "https://cdn.svgporn.com/logos/bitcoin.svg?response-content-disposition=attachment%3Bfilename%3Dbitcoin.svg"; _width logoSize; _height logoSize]
