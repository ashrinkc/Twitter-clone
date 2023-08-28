import React from "react";
import { message } from "../config/data";
import Messages, { IMsg } from "./Messages";

const MessageBox = () => {
  return (
    <div className=" h-[55vh] w-60 p-3 pb-5 border border-black bg-white">
      <div className="h-[10%] flex justify-between">
        <h1>Adhrin</h1>
        <p
          className="text-black-500 font-extrabold cursor-pointer"
          //   onClick={() => deleteHistory(data.id)}
        >
          X
        </p>
      </div>
      <hr className="mt-2 border border-black" />
      <div className="h-[80%] flex flex-col-reverse">
        {message.map((data: IMsg) => (
          <Messages
            msg={data.msg}
            senderId={data.senderId}
            receiverId={data.receiverId}
          />
        ))}
      </div>
      <div>
        <input className="w-[100%] p-1" placeholder="Write something" />
      </div>
    </div>
  );
};

export default MessageBox;
