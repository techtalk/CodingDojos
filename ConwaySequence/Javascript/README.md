Code taken from https://github.com/mochajs/mocha-examples/tree/master/packages/typescript

# Typescript application

Full documentation about it [here](https://mochajs.org/#-require-module-r-module)

## Commands

- `npm run compile` - compile the ES6 Typescript into the `/lib` directory
- `npm run lint` - run the Typescript linter using the `tslint.json` config file.
- `npm test` - run the tests using the local `.mocharc.json` config file. As the config includes the Typescript transpilation hook `ts-node/register` it does not require pre-compilation before running.