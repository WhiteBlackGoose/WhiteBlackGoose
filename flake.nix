{
  inputs.nixpkgs.url = "github:NixOS/nixpkgs/nixos-unstable";
  inputs.my-nix.url = "github:WhiteBlackGoose/my-nix/master";

  outputs = { nixpkgs, my-nix, ... }:
    let 
      systems = [ "aarch64-linux" "x86_64-linux" ]; in {
    devShells = nixpkgs.lib.genAttrs systems (sys: { 
      default =
      my-nix.dotnetShell
          nixpkgs.legacyPackages.${sys}
          (p: [ p.sdk_9_0 ])
          (p: [
            rec { 
              binName = "fsautocomplete";
              nugetName = binName;
              dllName = binName; 
              version = "0.77.4"; arch = "net9.0/any";
              sha256 = "sha256-R9okn2dHioLPK49EHV43FsmdgZD8ijJzgZOonSmQAdw=";
            }
            rec {
              binName = "dotnet-repl";
              nugetName = binName;
              dllName = binName;
              version = "0.3.230"; arch = "net9.0/any";
              sha256 = "sha256-I+LGFyiqmFxBIqQ6PhC9ZIEsU+yEtV4WFrm0nrI8biA=";
            } ]);
      });
  };
}
