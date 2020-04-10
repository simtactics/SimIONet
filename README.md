# SimPE.Interfaces

SimPE.Interfaces is a port of SimPE's Interface and Helper libraries to .NET Standard to allow for creation of new tools that depend only the absolute base functionality that SimPE provides.

## API Compatibility

This port is **not** 100% API compatible with SimPE itself. The Helper library lacks Windows Forms and Registry, references required by the application, in order to remain OS-agnostic. It contains only the necessary classes needed for the interface library to function properly.

They'll likely be a name change in the not-so-distance future in order to avoid confusion and potential breakage with existing tools.

## Build Status

| Service | Status                                                                                                                                                             |
| ------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| Github  | [![Build](https://img.shields.io/github/workflow/status/tonytins/SimPE.Interfaces/build/master?logo=github)](https://github.com/tonytins/SimPE.Interfaces/actions) |

## Authors

- **Anthony Foxclaw** - _Maintainer_ - [tonytins](https://github.com/tonytins)
- **Ambertation, Peter L Jones** - _Original work_

See also the list of [contributors](https://github.com/tonytins/SimPE.Interfaces/contributors) who participated in this project.

## License

This project is licensed under the GPL v2.0 or later license - see the [LICENSE](LICENSE) file for details.

## Disclaimer

This project is not affiliated with or endorsed by Electronic Arts or Maxis.
