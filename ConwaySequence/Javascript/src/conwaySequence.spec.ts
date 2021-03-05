import { equal } from "assert";
import {getConwaySequenceForRow, getNextRow} from "./conwaySequence";

describe("Conway Sequence", () => {
  it("should be able to execute a test", () => {
    equal(true, true);
  });
  it("Returns correct second row", () => {
    equal("11", getConwaySequenceForRow(2));
  });
  it("Returns default with negative number", () => {
    equal("1", getConwaySequenceForRow(-1));
  });
  it("Returns default on zero", () => {
    equal("1", getConwaySequenceForRow(0));
  });
  it("Returns correct first row", () => {
    equal("1", getConwaySequenceForRow(1));
  });
  it("Returns error message when result string would exceed limits", () => {
    equal("Sequence was too long to compute!", getConwaySequenceForRow(80));
    //Falls Einschränken der Inputs Option -> Memeoization (Dictionary von Zeile -> Output) statt algorithmus
  });
  it("Can handle decimal numbers", () => {
    //equal("13211311123113112211", getConwaySequenceForRow(10.87)); //10th Row OR
    equal("11131221133112132113212221", getConwaySequenceForRow(10.87)); //..11th Row
  });
  it("Returns correct row", () => {
    equal("11", getNextRow('31131211131221'));
  });
});

// Install Instructions:
// 1. npm i --save-dev @types/mocha
// 2. npm install --save mocha chai
// 3. npm test / VS Extensions -> Mocha Test Explorer

// example taken from: https://github.com/mochajs/mocha-examples/tree/master/packages/typescript