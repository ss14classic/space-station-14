# Space Station 14 Classic

<div class="header" align="center">  
<img alt="Space Station 14 Classic" src="https://files.catbox.moe/wlsfcn.png">  
</div>

This is the repository for Space Station 14 Classic. A fork of the **stable** branch of upstream [Space Station 14](https://github.com/space-wizards/space-station-14) that retains the classic textures we all know and love in favour of the so called "Respritening".

This point of this repository is to give downstream maintainers an alternative to rebase onto if they do not want to update their existing codebase and maps to use the new sprites, but still want to use the latest Wizden features.

This repo does not change any gameplay or technical related features from Wizden, it only reverts visual changes that have been made by the "Respritening".

## Why?

* The majority of the community does not like the Respritening.
  * https://forum.spacestation14.com/t/would-you-rather-the-respritening-remain-or-would-your-rather-return-wizden-to-the-classic-old-sprites-poll/28514
  * https://forum.spacestation14.com/t/do-you-support-the-respritening-poll/28479
* Accessibility: People report headaches and visibility problems.
  * https://forum.spacestation14.com/t/do-you-support-the-respritening-poll/28479/7
  * https://forum.spacestation14.com/t/resprite-looks-a-little-busy/28343
  * https://forum.spacestation14.com/t/some-respritening-feedback/28186
  * https://forum.spacestation14.com/t/detail-and-contrast-of-new-tiles-is-very-distracting/28545
* New tiles no longer have variants, making everything look "too clean".
* Every existing downstream map file will require significant alteration to work with the "Respritening" so this project will save mappers hundreds of collective hours.
* I subjectively prefer the old style.


## Links

<div class="header" align="center">  

 [Discord](https://discord.gg/6n66UfQmK) | [Stoat](https://stt.gg/EbCHhPsp)

 Discussion in the `#ss14-classic` channel. Stoat and Discord rooms are bridged.

</div>

## Contributing

This repository will not accept any new features, gameplay or balance alterations, you have to submit those to the upstream repository (Wizden).

Only PRs that fixes visual issues, maintains or improves the classic visuals will be accepted.

All YAML changes must include `# Classic: <reason>` comments for maintainability.

## Rebasing your fork onto Space Station Classic

Space Station 14 Classic is a drop-in replacement for the upstream **stable** branch. Reverts are done by adding new commits on top of stable. For ease of use the Git history has not been altered or rebased.

### 1. Point your fork at Classic

Add Classic as a remote alongside Wizden, so you can still diff against upstream:

```bash
git remote add classic git@github.com:ss14classic/space-station-14.git
git fetch classic
```

Or if you want to replace Wizden with Classic entirely:

```bash
git remote set-url upstream git@github.com:ss14classic/space-station-14.git
git fetch upstream
```

### 2. Merge

```bash
git checkout <your-branch>
git merge classic/stable
```

Conflicts will be concentrated mostly in `Resources/Prototypes`, `Resources/Textures` and `Resources/migration.yml`.

Every YAML change in Classic is annotated with a `# Classic: <reason>` comment to make merging easier.

### 3. Re-save your maps

**Only required if your maps were saved after the Respritening. Skip this step if all your map files are still pre-Respritening.**

Classic restores the tile variants the Respritening removed. Your maps will load fine, but tiles will have no variants, so floors will look really ad until they are resaved.

Build and start the development server, then run this in the server console (Classic exclusive):

```
variantizeallmaps
```

This runs the `variantize` command every map in the game and saves them to `bin/Content.Server/data/Maps/`.

Copy them back over the originals using:

```bash
rsync -a --existing bin/Content.Server/data/Maps/ Resources/Maps/
```

Using `--existing` is important so you don't accidentally copy procedurally generated maps during runtime.

### 4. Verify

```bash
dotnet run --project Content.YAMLLinter
```

If this returns no errors you probably did it right.

### Deviations from upstream to be aware of

Classic is not a full revert of the Respritening. The are some exceptions to be aware of:

* **Turnstiles.** While technically part of Respritening, upstream's `EnergyGate` replaces the old turnstiles, because they are functionally different than turnstiles.
* **Wall light positions.** Unrelated to the Respritening, a few days before Respritening upstream inverted the wall light's `PointLight.offset` which caused a lot of lighting issues. Classic reverts only the light offset change so lights look accurate to how they are supposed to be. See https://github.com/space-wizards/space-station-14/pull/44843/changes#diff-a416a956ea91c5bdf0b904245c06aa27f8b0d51fcaca2b7babf65382ed1cc94c
* **Bananium**. All bananium related content including the bananium science anomaly and bananium rock crabs have been fully restored. Worth mentioning because it is an actual gameplay change. All hail the bananium statue! HONK!
* **Rotated Wallmounts**. Added the rotatable versions of classic wallmounts made by [Codebreak](https://github.com/Codubreku). This is a definitive improvement as it makes it more clear to the players which way an APC for example is facing. [View PR](https://github.com/ss14classic/space-station-14/pull/1)

## License

All code for the content repository is licensed under the [MIT license](https://github.com/space-wizards/space-station-14/blob/master/LICENSE.TXT).  

Most assets are licensed under [CC-BY-SA 3.0](https://creativecommons.org/licenses/by-sa/3.0/) unless stated otherwise. Assets have their license and copyright specified in the metadata file. For example, see the [metadata for a crowbar](https://github.com/space-wizards/space-station-14/blob/master/Resources/Textures/Objects/Tools/crowbar.rsi/meta.json).  

> [!NOTE]
> Some assets are licensed under the non-commercial [CC-BY-NC-SA 3.0](https://creativecommons.org/licenses/by-nc-sa/3.0/) or similar non-commercial licenses and will need to be removed if you wish to use this project commercially.
