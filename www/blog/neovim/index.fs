module www.blog.neovim.index

open Giraffe.ViewEngine
open Page
open System.IO
open Utils

let refancs anc text =
    refanc anc text |> RenderView.AsString.htmlNode

type FeatureSource =
    | Builtin
    | Plugin of string * string

let ref featureSource =
    match featureSource with
    | Builtin -> i [] [ Text "&nbsp; (builtin)" ]
    | Plugin (repoOwner, repoName) -> span [] [ Text "&nbsp;("; a [_href $"https://github.com/{repoOwner}/{repoName}"] [ Text repoName ]; Text ")" ]

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
   Neovim is my favourite text/code/everything editor. I've been using it for a few years now, and I've never looked back. I'm lazy to write a full review, so here's a gallery and a feature list.
   """
  ]
  h2 [] [ anc "features"; Text "Feature List" ]
  p [] [
   Text "Most of nvim's power comes from plugins, but I also included some default features so IDE people would know what to expect if they switch. This is by no means an exhaustive list, there are just way too many plugins and features to list them all."
   ul [] [
    li [] [ 
     Text "Text Editing"
     ul [] [
      li [] [ Text "(neo)vi(m) keybindings (d'uh)" ]
      li [] [ Text "Find/replace in file and outside" ]
      li [] [ Text "Fuzzy search over a phrase in files"; ref <| Plugin ("nvim-telescope", "telescope.nvim") ]
      li [] [ Text "Undo tree"; ref <| Plugin ("mbbill", "undotree") ]
      li [] [ Text "Snappy leaps within code"; ref <| Plugin ("ggandor", "leap.nvim") ]
      li [] [ Text "Expansion of selection"; ref <| Builtin ]
      li [] [ Text "Tree Sitter to collapse and expand blocks"; ref <| Plugin ("nvim-treesitter", "nvim-treesitter") ]
     ]
    ]
    li [] [
     Text "Software Developing"
     ul [] [
      li [] [
       Text "Developing"
       ul [] [
        li [] [ Text "Syntactical and semantic highlighting"; ref <| Builtin; ref <| Plugin ("neovim", "nvim-lspconfig") ]
        li [] [ Text "Errors, warnings linting"; ref <| Builtin; ref <| Plugin ("neovim", "nvim-lspconfig") ]
        li [] [ Text "GoTo definition/declaration/references"; ref <| Builtin; ref <| Plugin ("neovim", "nvim-lspconfig") ]
        li [] [ Text "Code Actions"; ref <| Builtin; ref <| Plugin ("neovim", "nvim-lspconfig") ]
        li [] [ Text "Language-specific features (running tests, etc.)"; ref <| Plugin ("mrcjkb", "rustaceanvim"); ref <| Plugin ("ionide", "Ionide-vim"); Text " ..." ]
        li [] [ Text "Debugger"; ref <| Plugin ("mfussenegger", "nvim-dap"); ref <| Plugin ("rcarriga", "nvim-dap-ui") ]
        li [] [ Text "Diff (for merging and just diff-ing)"; ref <| Builtin; ref <| Plugin ("AndrewRadev", "linediff.vim") ]
       ]
      ]
      li [] [
       Text "Interactive Scripting"
       ul [] [
        li [] [ Text "Arbitrary REPL"; ref <| Plugin ("hkupty", "iron.nvim") ]
        li [] [ Text "Arbitrary Jupyter Kernel"; ref <| Plugin ("lkhphuc", "jupyter-kernel.nvim") ]
        li [] [ Text "Evaluation in place with Jupyter"; ref <| Plugin ("dccsillag", "magma-nvim") ]
       ]
      ]
      li [] [
       Text "Tooling"
       ul [] [
        li [] [ Text "Terminal Integration" ]
        li [] [ Text "LazyGit Integration"; ref <| Builtin ]
        li [] [ Text "Git Integration (Blame, etc.)"; ref <| Plugin ("lewis6991", "gitsigns.nvim"); ref <| Plugin ("tpope", "vim-fugitive") ]
       ]
      ]
     ]
    ]
    li [] [
     Text "Academia & Notes"
     ul [] [
      li [] [ Text "Orgmode: TODOs with weekly/monthy/yearly agenda"; ref <| Plugin ("WhiteBlackGoose", "orgmode") ]
      li [] [ Text "Orgmode: Rich formatting"; ref <| Plugin ("WhiteBlackGoose", "orgmode") ]
      li [] [ Text "Markdown preview (notes & charts)"; ref <| Plugin ("WhiteBlackGoose", "markdown-preview.nvim") ]
      li [] [ Text "Table mode to create markdown and orgmode tables"; ref <| Plugin ("dhruvasagar", "vim-table-mode") ]
      li [] [ Text "LaTeX: full LSP and preview"; ref <| Plugin ("lervag", "vimtex") ]
     ]
    ]
    li [] [
     Text "Miscellaneous"
     ul [] [
      li [] [ Text "Github CoPilot autocompletion in any file"; ref <| Plugin ("github", "copilot.vim") ]
      li [] [ Text "Keyboard-only snappy window management" ]
      li [] [ Text "gf and gx to go over paths" ]
      li [] [ Text "Util to pick colors in place"; ref <| Plugin ("nvim-colortils", "colortils.nvim") ]
     ]
    ]
   ]
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
