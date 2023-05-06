{
  inputs.nixpkgs.url = "github:NixOS/nixpkgs/nixos-unstable";
  inputs.my-nix.url = "github:WhiteBlackGoose/my-nix/master";

  outputs = { nixpkgs, my-nix, ... }:
    let 
      systems = [ "aarch64-linux" "x86_64-linux" ]; in {
    devShells = nixpkgs.lib.genAttrs systems (sys: { 
      default = my-nix.dotnetShell 
          nixpkgs.legacyPackages.${sys}
          (p: [ p.sdk_7_0 ])
          (p: [ p.fsautocomplete ])
        ; 
      });
  };
}
