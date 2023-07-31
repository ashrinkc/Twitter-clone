import React from "react";
import { history } from "../config/data";

const History = () => {
  return (
    <div className="p-2 flex flex-col gap-3 bg-gray-100 h-72 rounded-xl">
      <h1 className="font-bold text-xl">History</h1>
      {history.map((data) => (
        <div className="flex justify-between">
          <p className="font-serif">{data}</p>
          <p className="text-red-500 font-extrabold cursor-pointer">X</p>
        </div>
      ))}
    </div>
  );
};

export default History;
