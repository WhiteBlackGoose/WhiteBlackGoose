module www.``static``.media.icons

open Giraffe.ViewEngine

let link = """<svg class="octicon octicon-link" viewBox="0 0 16 16" version="1.1" width="16" height="16" aria-hidden="true"><path fill-rule="evenodd" d="M7.775 3.275a.75.75 0 001.06 1.06l1.25-1.25a2 2 0 112.83 2.83l-2.5 2.5a2 2 0 01-2.83 0 .75.75 0 00-1.06 1.06 3.5 3.5 0 004.95 0l2.5-2.5a3.5 3.5 0 00-4.95-4.95l-1.25 1.25zm-4.69 9.64a2 2 0 010-2.83l2.5-2.5a2 2 0 012.83 0 .75.75 0 001.06-1.06 3.5 3.5 0 00-4.95 0l-2.5 2.5a3.5 3.5 0 004.95 4.95l1.25-1.25a.75.75 0 00-1.06-1.06l-1.25 1.25a2 2 0 01-2.83 0z"></path></svg>"""
let mkImg src logoSize = img [_src src; _width logoSize; _height logoSize ]
let mkImgInv src logoSize = img [_src src; _width logoSize; _height logoSize; _class "inv" ]

let NeoVim = mkImg (Utils.locAwarePath "static/media/neovim.png")
let FSharp = mkImg "https://cdn.svgporn.com/logos/fsharp.svg?response-content-disposition=attachment%3Bfilename%3Dfsharp.svg"
let CSharp = mkImg "https://cdn.svgporn.com/logos/c-sharp.svg?response-content-disposition=attachment%3Bfilename%3Dc-sharp.svg"
let FStar = mkImg "https://www.fstar-lang.org/i/fstar-new.png"
let Bash = mkImg "https://github.com/odb/official-bash-logo/blob/61eff022f2dad3c7468f5deb4f06652d15f2c143/assets/Logos/Icons/PNG/128x128.png?raw=true"
let git = mkImg "https://cdn.svgporn.com/logos/git-icon.svg?response-content-disposition=attachment%3Bfilename%3Dgit-icon.svg"
let GNU = mkImgInv "https://cdn.svgporn.com/logos/gnu.svg?response-content-disposition=attachment%3Bfilename%3Dgnu.svg"
let bitcoin = mkImg "https://cdn.svgporn.com/logos/bitcoin.svg?response-content-disposition=attachment%3Bfilename%3Dbitcoin.svg"
let dotnet = mkImg "https://cdn.svgporn.com/logos/dotnet.svg?response-content-disposition=attachment%3Bfilename%3Ddotnet.svg"
let LaTeX = mkImg "https://user-images.githubusercontent.com/31178401/209452465-57d86bc4-e02d-4a10-9acd-f52a1e5c6062.png"
let Tor = mkImg "https://dl2.macupdate.com/images/icons256/17679.png?d=1522354611"
let eth = mkImg "https://cdn.svgporn.com/logos/ethereum-color.svg?response-content-disposition=attachment%3Bfilename%3Dethereum-color.svg"
let rust = mkImgInv "https://github.com/rust-lang/rust-artwork/blob/bf0b3272f9ba8d22f7fd45e408496d05621b3b5c/logo/rust-logo-128x128-blk-v2.png?raw=true"
let haskell = mkImg "https://wiki.haskell.org/wikiupload/4/4a/HaskellLogoStyPreview-1.png"
let ens = mkImg "https://coindoo.com/wp-content/uploads/2019/02/ens-logo.png"
let Draco = mkImg "https://avatars.githubusercontent.com/u/112573644?s=200&v=4"
let lua = mkImg "https://upload.wikimedia.org/wikipedia/commons/c/cf/Lua-Logo.svg"

let NixOS = mkImg "https://raw.githubusercontent.com/NixOS/nixos-artwork/c1dc75611042b57a385c80495d3728724c35cfee/logo/nix-snowflake.svg"
let fedora = mkImg "https://linux-man.org/wp-content/uploads/2021/09/Fedora_logo.svg"
let debian = mkImg "https://linux-man.org/wp-content/uploads/2021/09/openlogo.svg"
let ubuntu = mkImg "https://linux-man.org/wp-content/uploads/2021/09/cof_orange_hex.svg"
let arch = mkImg "https://cdn.svgporn.com/logos/archlinux.svg?response-content-disposition=attachment%3Bfilename%3Darchlinux.svg"
let mint = mkImg "https://cdn.svgporn.com/logos/linux-mint.svg?response-content-disposition=attachment%3Bfilename%3Dlinux-mint.svg"
let FreeBSD = mkImg "https://cdn.svgporn.com/logos/freebsd.svg?response-content-disposition=attachment%3Bfilename%3Dfreebsd.svg"
let xubuntu = mkImg "https://upload.wikimedia.org/wikipedia/commons/a/a0/Xubuntu-logo.svg"
let kubuntu = mkImg "https://upload.wikimedia.org/wikipedia/commons/1/1f/Kubuntu_logo.svg"
let Windows = mkImg "https://upload.wikimedia.org/wikipedia/commons/5/5f/Windows_logo_-_2012.svg"
let iOS = mkImg "https://upload.wikimedia.org/wikipedia/commons/c/ca/IOS_logo.svg"
let Android = mkImg "https://upload.wikimedia.org/wikipedia/commons/d/d7/Android_robot.svg"

let noFacebook = img [_src "https://stallman.org/no-facebook.svg"; _width "200"; _style "float: right;"]
