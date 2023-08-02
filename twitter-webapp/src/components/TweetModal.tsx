import React from "react";
import InputTweet from "./InputTweet";
import CloseIcon from "@mui/icons-material/Close";

type IOpen = {
  setOpen: (value: boolean) => void;
};

const TweetModal = ({ setOpen }: IOpen) => {
  return (
    <div className=" flex flex-col gap-3 w-[40vw]">
      <h1
        className="font-mono text-xl cursor-pointer"
        onClick={() => setOpen(false)}
      >
        <CloseIcon />
      </h1>
      <InputTweet />
    </div>
  );
};

export default TweetModal;
