import InsertCommentIcon from "@mui/icons-material/InsertComment";
import ReplayIcon from "@mui/icons-material/Replay";
import FavoriteBorderIcon from "@mui/icons-material/FavoriteBorder";
import { Link } from "react-router-dom";
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
  retweeted?: boolean;
  id?: number;
  isLike?: boolean;
  likes?: number;
  quotes?: number;
  comments?: number;
  creatorId?: number;
  setRefresh: (value: boolean) => void;
  refresh: boolean;
}
const Posts = ({
  profileImg,
  name,
  username,
  desc,
  postImg,
  retweeted,
  id,
  isLike,
  likes,
  quotes,
  comments,
  setRefresh,
  creatorId,
  refresh,
}: IPost) => {
  const user = useSelector((state: RootState) => state.auth.currentUser);
  const handleLike = async () => {
    const data = {
      userId: user.id,
      postId: id,
    };
    try {
      const res = await axios.post(`${api}/likeUnlike`, data);
      console.log(res.data);
      setRefresh(!refresh);
    } catch (err) {
      console.log(err);
    }
  };

  const handleQuote = async () => {
    try {
      const res = await axios.post(`${api}/quote/${id}?userId=${user.id}`);
      console.log(res.data);
    } catch (err) {
      console.log(err);
    }
  };
  return (
    <Link
      to={`/p/${id}`}
      state={{
        id,
        name,
        profileImg,

        username,
        desc,
        postImg,
        retweeted,

        isLike,
        likes,
        quotes,
        comments,
      }}
    >
      <div className="hover:bg-gray-100 p-2">
        <div
          className={`flex gap-2 pl-3 pb-2 text-xs ${
            retweeted ? "block" : "hidden"
          }`}
        >
          <ReplayIcon style={{ fontSize: "20px" }} />
          <p>You retweeted</p>
        </div>

        <div className="flex gap-3">
          <div className="w-[8%]">
            <Link to={`/profile`} state={creatorId}>
              <img
                className=" rounded-full h-10"
                src={
                  profileImg
                    ? profileImg
                    : "https://www.spongebobshop.com/cdn/shop/products/SB-Standees-Spong-3_800x.jpg?v=1603744568"
                }
              />
            </Link>
          </div>
          <div className="w-[100%]">
            <h5 className="font-semibold">
              {name} <a className="text-gray-500 font-medium">{username}</a>
            </h5>
            <p>{desc}</p>
            <img className=" rounded-xl mt-4 max-h-[60vh]" src={postImg} />

            <div className="flex gap-10 mt-2 ">
              <p>
                <InsertCommentIcon /> {comments}
              </p>
              {/* <p onClick={handleQuote}>
                <ReplayIcon /> {quotes}
              </p> */}
              <p
                onClick={(e) => {
                  e.preventDefault();
                  handleLike();
                }}
              >
                <span>
                  <FavoriteBorderIcon
                    className={`${isLike && "text-red-500"}`}
                  />{" "}
                </span>
                {likes}
              </p>
            </div>
          </div>
        </div>
      </div>
    </Link>
  );
};

export default Posts;
