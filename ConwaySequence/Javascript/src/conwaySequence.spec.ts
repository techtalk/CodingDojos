import { equal } from "assert";
import {getConwaySequenceForRow} from "./conwaySequence";

describe("Conway Sequence", () => {
  it("should be able to execute a test", () => {
    equal(true, true);
  });
  it("Returns correct second row", () => {
    equal("11", getConwaySequenceForRow(2));
  });
});

// Install Instructions:
// 1. npm i --save-dev @types/mocha
// 2. npm install --save mocha chai
// 3. npm test / VS Extensions -> Mocha Test Explorer

// example taken from: https://github.com/mochajs/mocha-examples/tree/master/packages/typescript