import ImageIcon from "@mui/icons-material/Image";
import EmojiEmotionsIcon from "@mui/icons-material/EmojiEmotions";
import { RefObject, useEffect, useRef, useState } from "react";
import { useSelector } from "react-redux";
import { RootState } from "../redux/store";
import { IUserData } from "../redux/authSlice";
import axios from "axios";
import { api } from "../config/data";
const InputTweet = ({
  Iref,
  setChange,
  change,
}: {
  Iref?: RefObject<HTMLInputElement>;
  setChange: (value: boolean) => void;
  change: boolean;
}) => {
  const user = useSelector((state: RootState) => state.auth.currentUser);
  const inputFileRef = useRef<HTMLInputElement | null>(null);
  const [input, setInput] = useState("");
  const [empty, isEmpty] = useState(true);
  const [image, setImage] = useState<File | Blob | null | any>(null);

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
      image: image ? image : null,
    };
    try {
      const res = await axios.post(`${api}/post`, data);
      setInput("");
      setChange(!change);
      console.log(res.data);
    } catch (err) {
      console.log(err);
    }
  };

  const handleImageUpload = () => {
    inputFileRef.current?.click();
  };

  const onImageChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    if (e.target.files && e.target.files[0]) {
      const file = e.target.files[0];
      console.log(file);
      setFiletoBase(file);
    }
  };

  const setFiletoBase = (file: File | Blob | null | any) => {
    if (file) {
      const reader = new FileReader();
      reader.readAsDataURL(file);
      reader.onloadend = () => {
        setImage(reader.result);
        console.log(reader.result);
      };
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
          <ImageIcon style={{ fontSize: "20px" }} onClick={handleImageUpload} />
          {/* <EmojiEmotionsIcon style={{ fontSize: "20px" }} /> */}
          <input
            onChange={onImageChange}
            ref={inputFileRef}
            style={{ display: "none" }}
            type="file"
          />
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
