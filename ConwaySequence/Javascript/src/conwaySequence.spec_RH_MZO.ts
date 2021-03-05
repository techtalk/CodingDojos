import { equal, deepEqual } from "assert";
import {getConwaySequenceForRow, getStringArray, getNextSequence, compareWithNextPosition} from "./conwaySequence";

describe("Conway Sequence", () => {
  it("should be able to execute a test", () => {
    equal(true, true);
  });
  it("Returns correct second row", () => {
    equal("11", getConwaySequenceForRow(2));
  });
  it("Returns correct third row", () => {
    equal("21", getConwaySequenceForRow(3));
  });
  it("Returns correct forth row", () => {
    equal("1211", getConwaySequenceForRow(4));
  });
  it("Returns correct fifth row", () => {
    equal("111221", getConwaySequenceForRow(5));
  });
  it("Returns correct sixth row", () => {
    equal("312211", getConwaySequenceForRow(6));
  });
});


describe("StringSpliter", () => {
  it("should return char Array", () => {
    deepEqual(['1','1'], getStringArray("11"));
  })
})

describe("NextSequence", () => {
  it("when 11 should return 21", () => {
    equal("21", getNextSequence("11"));
  }),
  it("when 111 should return 31", () => {
    equal("31", getNextSequence("111"));
  }),
  it("when 12 should return 1112", () => {
    equal("1112", getNextSequence("12"));
  }),
  it("when 112 should return 2112", () => {
    equal("2112", getNextSequence("112"));
  }) 
  
})

describe("compareWithNextPosition", () => {
  it("when value position 1 in array ", () => {
    equal(true, compareWithNextPosition(['1','1'],0));
  }),
  it("when value position 1 in array ", () => {
    equal(false, compareWithNextPosition(['1','2'],0));
  })
})
// Install Instructions:
// 1. npm i --save-dev @types/mocha
// 2. npm install --save mocha chai
// 3. npm test / VS Extensions -> Mocha Test Explorer

// example taken from: https://github.com/mochajs/mocha-examples/tree/master/packages/typescript