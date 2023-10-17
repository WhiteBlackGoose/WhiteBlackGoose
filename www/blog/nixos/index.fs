module www.blog.nixos.index

open Giraffe.ViewEngine
open Page

let orderedHeader =
    let mutable counter = 0
    fun text ->
        counter <- counter + 1
        Text $"{counter}. {text}"

let orderedHeader2 =
    let mutable counter = 0
    fun text ->
        counter <- counter + 1
        Text $"{counter}. {text}"

let refancs anc text =
    refanc anc text |> RenderView.AsString.htmlNode

let html = PageWrap.wrap www.``static``.styles.css {
 title = "Why I love NixOS"
 url = "blog/nixos"
 filename = "index.html"
 contents = [
  p [] [
   Text $"""
   As of {System.DateTime.Now.ToUniversalTime().ToString("yyyy-MM-dd")}, NixOS is my favourite operating system, and here's why. (this article is WIP)
   """
  ]
  br []
  hr []
  br []

  h2 [] [ anc "text"; orderedHeader $"""Text configuration""" ]
  p [] [
   Text $"""
    The entire system is configured through text. And by config I mean, not time zone or host name - everything. All systemd services, grub, keyboard, drivers, kernel modules, dns resolvers, installed software - oh, list of software is also configured through text.
   """
  ]
  p [] [
   Text $"""
    Text configuration has a lot of benefits. Besides the fact, that everything is under your control in one place and not stretched by all kinds of things, it also makes {it "your entire system"} git-friendly - that is, you can pretty much version control your system configuration, and thus, spend just a few minutes recovering your whole system if something happens to your hardware.
      """
  ]
  p [] [
   Text $"""
    It also means you can easily share your configuration. Instead of following imperative steps of some guide, you just copy-paste some piece of configuration and rebuild the system - boom, it works.
   """
  ]

  h2 [] [ anc "repro"; orderedHeader "Reproducibility" ]
  p [] [
   Text $"""
    Nix is pure, given the same input (configuration) - it produces the same output. That means, you can easily try something out, and rollback - the rolled back system will be the same as it was before you tried it.
   """
  ]
  p [] [
   Text $"""
    Moreover, Nix will take care of package dependencies when you're creating a nix package, to ensure that the build is reproducible. If it builds for you - it builds for everyone else (at least, with the same architecture and OS). That opposed to traditional OS like Debian, where you have to ensure that you listed all dependencies for the package, and not miss a few which are installed on your system, but you forgot that they're needed.
   """
  ]

  h2 [] [ anc "sandbox"; orderedHeader "Package sandboxing" ]
  p [] [
   Text $"""
    All packages and dependencies have unique paths (hashes) generated for them by {co "nix"}. That means, we could really go wild with packages. We could have multiple deps of different versions - or we could have multiple apps of different versions - or even multiple core libraries like glibc! Hell, we could quite literally have non-conflicting instances of every program in all their available versions. All you need is to run them by figuring out the path - but remember, path is just a hash of the program+version! You can calculate it even before you "install" it.
   """
  ]
  p [] [
   Text $"""
    Although we probably don't normally want to have 16 versions of firefox, we might want to partially upgrade some packages - which is impossible in "linear" OS like debian, arch, ubuntu, and others. Here - you're free to. 
   """
  ]

  h2 [] [ anc "easy-use"; orderedHeader "Easy to use" ]
  p [] [
   Text $"""Not in the same way as Linux Mint or Ubuntu (it's actually quite the opposite). But when you start somewhat getting into it - a lot of things get much easier. For instance, configuring services, or swapping linux kernels. You {it "just"} replace the corresponding line in your config with the kernel you want. For most simple cases, you can just copy stuff from wiki and get away with it.
   """
  ]
  p [] [
   Text $"""Besides what I listed, here's a practical example of what I mean. I use my own fork of neovim. On other OS I'd need to remove the original {co "neovim"} from my system with the package manager, then clone my repo, and build it. On NixOS, I replace my original config:
   """
  ]
  pre [] [
   code [] [
    Text $"""environment.systemPackages = with pkgs; [
    neovim
]"""
   ]
  ]
  p [] [
   Text $"""With a "fork" of this package, with git url and commit hash overriden:"""
  ]
  pre [] [
   code [] [
    Text $"""environment.systemPackages = with pkgs; [
    (
      neovim-unwrapped.overrideAttrs (oldAttrs: {{
        src = fetchFromGitHub {{
          owner = "WhiteBlackGoose";
          repo = "neovim-goose";
          rev = "5c9bf0ea74aa9297227242f17058a9f0c4c0c115";
          hash = "sha256-s+c745H4D9hTOWTmPKG0emp4TMiJlFhhF9zCeqnIDB4=";
        }};
      }})
    )
]"""
   ]
  ]
  p [] [
   Text $"""See? I just replaced a few attributes. Now I use my fork. I didn't even read nvim's guide on how to build it. And I didn't bother installing its build and runtime dependencies either."""
  ]

  h2 [] [ anc "app-avail"; orderedHeader "Software availability" ]
  p [] [
   Text $"""You may have expected, that some obscure OS which nobody has heard of has almost no packages, and you're forced to escape the package manager with regular builds very soon? Haha. According to {_a "https://repology.org/repositories/statistics/total" "repology.org"}, it has quite literally the {bo "richest"} softare repository in the world, superceding AUR - and we haven't even talked about NUR (NixOS User Repository) yet, only about the official one!
   """
  ]
  p [] [
   Text $"""Of course, you should take that source with a grain of salt. Not because they lie - but because there's no objective way to calculate the number of packages. For example, do multiple versions count? Do python packages count (and they exist in nix)? How do we really know if many packages = rich? Maybe your favourite program is only available for Trisquel?"""
  ]
  p [] [
   Text $"""Nonetheless, by {it "my"} experience I could find many more packages in NixOS than, let's say, in debian. One of the reasons - because it's {refancs "easy-contrib" "so easy to contribute"}."""
  ]

  h2 [] [ anc "shell"; orderedHeader "Shell and Develop" ]
  p [] [
   Text $"""With {co "nix-shell -p"} you can try packages without "installing" them. For example, you want to run {co "neofetch"}, but you don't want to keep it in PATH constantly. So you do {co "nix-shell -p neofetch"}, now you're in a shell. There you can run it, then exit - and neofetch is entirely inaccessible. No, {co "nix"} didn't delete it. It's just that it made it accessible for your session."""
  ]
  p [] [
   Text $"""But we didn't really cover the actual power of {co "nix-shell"}. Yes you can try out packages with it - but you can as well build an entire development environment! You can create *.nix files for your projects, and configure all toolchains, buildtools, compilers, SDKs, packages and dependencies that your project needs - so that new teammates could easily immerse into your process by {it "just"} typing {co "nix-shell amazing-project.nix"}, and others - synchronize your SDKs."""
  ]

  h2 [] [ anc "flakes"; orderedHeader "Flakes" ]
  p [] [
    Text $"""Now there are flakes. Although they're still in the experimental phase, the community is actively using them. So am I (this project uses a flake btw). Flake is just a whole different level."""
  ]
  p [] [
    Text $"""Flake is like a hub with inputs and outputs. Physically, flake is a directory (most of the time, git repo) with two files: {co "flake.nix"} and {co "flake.lock"}. {co "flake.lock"} pins exact hashes for inputs, supplied to {co "flake.nix"}. Now {co "flake.nix"} is a file, which defines inputs and outputs. Inputs are other flakes! Outputs are entirely up to you, you can return anything. For example, you can take in a flake which defines a factorial function and return a factorial of 5. Now someone else can use your flake."""
  ]
  p [] [
    Text $"""For software development, you will probably use flakes with software derivations. The largest nix repo is {co "nixpkgs"}, maintained by the NixOS team. You simply pull it and you will be able to use these packages in your development environment."""
  ]
  p [] [
    Text $"""Now what's the benefit? Well, the flake's output, besides just pure expressions (we aren't doing an FP course here), can also be interpreted for useful stuff. First, system configuration. If your output has system configuration type, your whole system will be rebuilt according to it. Second, development environment. Once you meet the criteria so to say, running {co "nix develop"} will get you into development shell with the tooling you need (and whatever you specified). And finally, same with {co "nix shell"} for actually trying out the package. So you can have development environment and user environment in your project, and while your team simply pulls in your flake without having to install the software on their own, any user can simply pull the flake as well for installation!"""
  ]
  p [] [
   Text $"""I like thinking of flakes as of a way to distribute and redistribute nix expressions. In the end of the day what you get with nix is a complete working system or environment. And thanks to flakes, you can share and exchange parts of those environments with others! In particular, some projects are "distributed" via flakes. Instead of them instructing you how to build a program, they do it themselves in a flake. For you, what you do is you fetch a flake which instructs nix how to install an app (as such, flakes don't have to be in the same repo, you can create your own flake which installs gimp + krita at a time and provides a desktop entry which calls them both)."""
  ]

  h2 [] [ anc "ext"; orderedHeader "Extensible" ]
  p [] [
   Text $"""The line between installed software and the OS is more blurry than on other OS, since you have more control over how this software is invoked and configured. For example, you can wrap running certain programs into custom scripts directly in desktop entries. You can extend and override some packages as covered in {refancs "easy-use" "one of the previous sections"}. For example, if you want working OCR in your system, you can create the following {it "module"}:"""
  ]
  pre [] [
   code [] [
    Text """{ pkgs, ... }: {
  xdg.desktopEntries = 
    let 
      ocr = lang: {
        name = "OCR image: ${lang}";
        exec = "${pkgs.writeScript "ocr" ''
          ${pkgs.xfce.xfce4-screenshooter}/bin/xfce4-screenshooter -r --save /dev/stdout | \
          ${pkgs.tesseract}/bin/tesseract -l ${lang} - - | \
          ${pkgs.xclip}/bin/xclip -sel clip
        ''}";
      };
      ocr-trans = lang-src: lang-dst: {
        name = "OCR translate: ${lang-src} -> eng";
        exec = "${pkgs.writeScript "tr" ''
          ${pkgs.xfce.xfce4-screenshooter}/bin/xfce4-screenshooter -r --save /dev/stdout | \
          ${pkgs.tesseract}/bin/tesseract -l ${lang-src} - - | \
          tr '\n' ' ' |\
          ${pkgs.translate-shell}/bin/trans -t "${lang-dst}" -b | \
          ${pkgs.writeScript "stdin-to-yad" "
            text=
            while read line
            do
              text=\"$text $line\"
            done
            ${pkgs.yad}/bin/yad --text \"$text\" --no-buttons --escape-ok --text-align=center
          "}
        ''}";
      };
    in
  {
    ocr-en = ocr "eng";
    ocr-ru = ocr "rus";
    ocr-de = ocr "deu";
    ocr-all = ocr "eng+rus+deu";
    ocr-tr-deu = ocr-trans "deu" "en";
    ocr-tr-jpn = ocr-trans "jpn+eng" "en";
  };
}

    """
   ]
  ]
  p [] [
   Text $"""This code is plug-and-play module for NixOS that I wrote for myself to achieve """; a [_href "https://www.reddit.com/r/NixOS/comments/13uboa6/text_from_image_to_clipboard_nix_tip/"] [Text "this"]; Text ".";
  ]
  p [] [
   Text $"""What I mean by plug-and-play is that it's not just a plain script that you could otherwise do yourself. On regular OS like Ubuntu you'd need to write this script file, install all needed software, and create a .desktop file to make it available on the app launcher."""
  ]
  p [] [
   Text $"""This is why I call it an "extension" of the OS. You aren't really managing separate packages, they will be automatically "installed" as they are referenced by this module. Moreover, because it's written in the nix programming language, you can enjoy actual programming in it. In particular, in this example I create multiple desktop entries for different langauges. And you can easily share this module with someone too!"""
  ]

  h2 [] [ anc "easy-contrib"; orderedHeader "Easy to contribute" ]
  p [] [
   Text $"""It's orders of magnitude easier to package an app for NixOS than, let's say, for debian. The package is a *.nix file, which creates a {it "derivation"} (that's what the packages you install are, too). It declares dependencies and all that - somewhat similar to other package managers, but unlike them, nix guarantees that all dependencies are well-defined, and you didn't mutate something accidentally to make it build, because it reproduces everything from scratch on rebuild.
   """
  ]
  p [] [
   Text $"""Of course, you don't want to rebuild every single time you just want to see if it builds. So you can enter {refancs "shell" "shell"} - with all dependencies available, but without building the app itself, so you can tinker and mutate while you're at it - and then see, if it actually reproduces from clean state"""
  ]
  p [] [
   Text $"""Not only that, but it's also very easy to send the new package upstream. Unlike other OS, NixOS' repository, nixpkgs, is {_a "https://github.com/nixOS/nixpkgs/" "managed on github"}. That means, uploading a package is as hard as creating a pull request."""
  ]
  p [] [
   Text $"""As a bonus of that repo management, you can keep your own fork of {co "nixpkgs"} and pull packages from there - or {it "some"} packages from there, and others from upstream - or however you wish, honestly."""
  ]

  h1 [] [ anc "disadvantages"; Text "Disadvantages" ]
  p [] [
   Text $"""Nobody expected that, but NixOS also has disadvantages."""
  ]

  h2 [] [ anc "learn"; orderedHeader2 "A lot to learn" ]
  p [] [
   Text $"""This is really super-different from other GNU/Linux and Unix-like operating systems. Your configuration is managed through pure functional language {co "nix"}, which you will have to learn eventually. The language is far less complicated than, let's say, Haskell, but nonetheless - it's just for system configuration, and not everyone expects that."""
  ]

  h2 [] [ anc "docs"; orderedHeader2 "Docs could be better" ]
  p [] [
   Text $"""One of advantages of Arch and Ubuntu - is how large their community is, how advanced docs or wiki are. Arch is famous for its archwiki, which is referred by wikis of other OS - like debian, gentoo, and NixOS too. However, NixOS' wiki is far from it. Although for many things you will find help there, for the rest - you're on your own, most of the time. """
  ]
  p [] [
   Text $"""For the sake of completeness, {_a "https://github.com/nix-community/awesome-nix#resources" "here"} you can see the list of resources to learn from."""
  ]

  h2 [] [ anc "sometimes-hard"; orderedHeader2 "Many things may be harder" ]
  p [] [
   Text $"""... than in other OS. For instance, .NET SDK doesn't always work for me (skill issue?), because SDK resolution tool is getting lost in installed .NETs. Although I'm sure I'll figure it out (and it will be even better than on other distros), it already took me some time that you could've spent on developing the app on Ubuntu or Windows."""
  ]
  p [] [
   Text $"""Some rare programs (e. g. user-contributed drivers) are (naturally) written for mutable distros, so they'd write a service file, invoke systemctl, write there and there. For NixOS, you will have to write that in your text configuration. So many things are NixOS-only, and you cannot just use the same thing."""
  ]
  
  h2 [] [ anc "not-everything"; orderedHeader2 "Not everything is reproducible" ]
  p [] [
   Text $"""I {refancs "repro" "described"} reproducibility - and it is 100%% true for {co "/nix/store"}. However, a lot of things are not. Most major one would be {co "~/.config"} - user configuration of software. Some of software can be configured through home-manager, but most of it cannot, so you either have to generate that file manually through nix - or not bother and create it in that path manually, as you'd do on other distros."""
  ]
 ]
}
