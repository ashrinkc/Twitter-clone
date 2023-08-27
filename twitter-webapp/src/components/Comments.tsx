import ReplayIcon from "@mui/icons-material/Replay";
import FavoriteBorderIcon from "@mui/icons-material/FavoriteBorder";
import { useSelector } from "react-redux";
import { RootState } from "../redux/store";
import axios from "axios";
import { api } from "../config/data";

export interface IPost {
  profileImg?: string;
  name: string;
  username: string;
  desc?: string;
  postImg?: string;
  id: number;
  created?: string;
  quotes: number;
  like: number;
  isLike: boolean;
}

const Comments = ({
  id,
  profileImg,
  name,
  username,
  desc,
  postImg,
  created,
  quotes,
  like,
  isLike,
}: IPost) => {
  const user = useSelector((state: RootState) => state.auth.currentUser);

  const handleLike = async () => {
    const data = {
      userId: user.id,
      commentId: id,
    };
    try {
      const res = await axios.post(`${api}/like`, data);
      console.log(res.data);
    } catch (err) {
      console.log(err);
    }
  };

  return (
    <div className="hover:bg-gray-100 p-3 border border-gray-200">
      <div className="flex gap-3">
        <div className="w-[8%]">
          <img
            className=" rounded-full h-9"
            src={
              profileImg
                ? profileImg
                : "https://www.spongebobshop.com/cdn/shop/products/SB-Standees-Spong-3_800x.jpg?v=1603744568"
            }
          />
        </div>
        <div className="w-[100%]">
          <h5 className="font-semibold">
            {name} <a className="text-gray-500 font-medium">{username}</a>
          </h5>
          <p>{desc}</p>
          <img className=" rounded-xl mt-4 max-h-[60vh]" src={postImg} />
          <div className="flex mt-2 ">
            {/* <p>
              <ReplayIcon /> {quotes}
            </p> */}
            <p onClick={handleLike}>
              <FavoriteBorderIcon className={`${isLike && "text-red-500"}`} />{" "}
              {like}
            </p>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Comments;
