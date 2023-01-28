module www.blog.nixos.index

open Giraffe.ViewEngine
open Page

let orderedHeader =
    let mutable counter = 0
    fun text ->
        counter <- counter + 1
        Text $"{counter}. {text}"

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

  h2 [] [ anc "repro"; orderedHeader "2. Reproducibility" ]
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

  h2 [] [ anc "sandbox"; orderedHeader "3. Package sandboxing" ]
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

  h2 [] [ anc "shell"; orderedHeader "4. Shell" ]
  p [] [
   Text $"""With {co "nix-shell -p"} you can try packages without "installing" them. For example, you want to run {co "neofetch"}, but you don't want to keep it in PATH constantly. So you do {co "nix-shell -p neofetch"}, now you're in a shell. There you can run it, then exit - and neofetch is entirely inaccessible. No, {co "nix"} didn't delete it. It's just that it made it accessible for your session."""
  ]
  p [] [
   Text $"""But we didn't really cover the actual power of {co "nix-shell"}. Yes you can try out packages with it - but you can as well build an entire development environment! You can create *.nix files for your projects, and configure all toolchains, buildtools, compilers, SDKs, packages and dependencies that your project needs - so that new teammates could easily immerse into your process by {it "just"} typing {co "nix-shell amazing-project.nix"}, and others - synchronize your SDKs."""
  ]

  h2 [] [ anc "easy-use"; orderedHeader "5. Easy to use" ]
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

  h2 [] [ anc "easy-contrib"; orderedHeader "6. Easy to contribute" ]
  p [] [
   Text $"""It's orders of magnitude easier to package an app for NixOS than, let's say, for debian. The package is a *.nix file, which creates a {it "derivation"} (that's what the packages you install are, too). It declares dependencies and all that - somewhat similar to other package managers, but unlike them, nix guarantees that all dependencies are well-defined, and you didn't mutate something accidentally to make it build, because it reproduces everything from scratch on rebuild.
   """
  ]
  p [] [
   Text $"""Of course, you don't want to rebuild every single time you just want to see if it builds. So you can enter {refanc "shell" "shell"} - with all dependencies available, but without building the app itself, so you can tinker and mutate while you're at it - and then see, if it actually reproduces from clean state"""
  ]
  p [] [
   Text $"""Not only that, but it's also very easy to send the new package upstream. Unlike other OS, NixOS' repository, nixpkgs, is {_a "https://github.com/nixOS/nixpkgs/" "managed on github"}. That means, uploading a package is as hard as creating a pull request."""
  ]
  p [] [
   Text $"""As a bonus of that repo management, you can keep your own fork of {co "nixpkgs"} and pull packages from there - or {it "some"} packages from there, and others from upstream - or however you wish, honestly."""
  ]

  h2 [] [ anc "app-avail"; orderedHeader "7. Software availability" ]
  p [] [
   
  ]
 ]
}
