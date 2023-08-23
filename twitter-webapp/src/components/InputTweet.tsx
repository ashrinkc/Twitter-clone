import ImageIcon from "@mui/icons-material/Image";
import EmojiEmotionsIcon from "@mui/icons-material/EmojiEmotions";
import { RefObject, useEffect, useState } from "react";
import { useSelector } from "react-redux";
import { RootState } from "../redux/store";
import { IUserData } from "../redux/authSlice";
import axios from "axios";
import { api } from "../config/data";
const InputTweet = ({ Iref }: { Iref?: RefObject<HTMLInputElement> }) => {
  const user = useSelector((state: RootState) => state.auth.currentUser);
  const [input, setInput] = useState("");
  const [empty, isEmpty] = useState(true);
  useEffect(() => {
    Iref?.current?.focus();
  }, []);
  useEffect(() => {
    if (input.length > 0) {
      isEmpty(false);
    } else {
      isEmpty(true);
    }
  }, [input, setInput]);
  const handleClick = async (e: React.MouseEvent<HTMLButtonElement>) => {
    e.preventDefault();
    if (input.length <= 0) {
      alert("nono");
      return;
    }
    const data = {
      description: input,
      userId: user.id,
    };
    try {
      const res = await axios.post(`${api}/post`, data);
    } catch (err) {
      console.log(err);
    }
  };
  return (
    <div className="flex flex-col gap-1">
      <div className="flex gap-1">
        <img
          className=" rounded-full h-10"
          src="https://www.spongebobshop.com/cdn/shop/products/SB-Standees-Spong-3_800x.jpg?v=1603744568"
        />
        <input
          className="w-[100%] p-1 focus:outline-none"
          placeholder="What is happening?"
          ref={Iref}
          value={input}
          onChange={(e) => setInput(e.target.value)}
        />
      </div>
      <div className="pl-11 flex justify-between items-center">
        <div className="flex gap-1">
          <ImageIcon style={{ fontSize: "20px" }} />
          <EmojiEmotionsIcon style={{ fontSize: "20px" }} />
        </div>
        <div>
          <button
            className={`${
              empty ? "bg-blue-300" : "bg-blue-500"
            } text-white p-1 px-8 rounded-xl`}
            onClick={handleClick}
          >
            Tweet
          </button>
        </div>
      </div>
    </div>
  );
};

export default InputTweet;
