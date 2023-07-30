import ImageIcon from "@mui/icons-material/Image";
import EmojiEmotionsIcon from "@mui/icons-material/EmojiEmotions";
const InputTweet = () => {
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
        />
      </div>
      <div className="pl-11 flex justify-between items-center">
        <div className="flex gap-1">
          <ImageIcon style={{ fontSize: "20px" }} />
          <EmojiEmotionsIcon style={{ fontSize: "20px" }} />
        </div>
        <div>
          <button className="bg-blue-300 text-white p-1 px-8 rounded-xl">
            Tweet
          </button>
        </div>
      </div>
    </div>
  );
};

export default InputTweet;
