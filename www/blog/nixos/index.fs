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

  h2 [] [ anc "shell"; orderedHeader "Shell" ]
  p [] [
   Text $"""With {co "nix-shell -p"} you can try packages without "installing" them. For example, you want to run {co "neofetch"}, but you don't want to keep it in PATH constantly. So you do {co "nix-shell -p neofetch"}, now you're in a shell. There you can run it, then exit - and neofetch is entirely inaccessible. No, {co "nix"} didn't delete it. It's just that it made it accessible for your session."""
  ]
  p [] [
   Text $"""But we didn't really cover the actual power of {co "nix-shell"}. Yes you can try out packages with it - but you can as well build an entire development environment! You can create *.nix files for your projects, and configure all toolchains, buildtools, compilers, SDKs, packages and dependencies that your project needs - so that new teammates could easily immerse into your process by {it "just"} typing {co "nix-shell amazing-project.nix"}, and others - synchronize your SDKs."""
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
