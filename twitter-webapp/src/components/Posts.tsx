import InsertCommentIcon from "@mui/icons-material/InsertComment";
import ReplayIcon from "@mui/icons-material/Replay";
import FavoriteBorderIcon from "@mui/icons-material/FavoriteBorder";
import { Link } from "react-router-dom";

export interface IPost {
  profileImg?: string;
  name: string;
  username: string;
  desc?: string;
  postImg?: string;
  retweeted?: boolean;
  id?: string;
  isLike?: boolean;
  likes?: number;
  quotes?: number;
  comments?: number;
  creatorId?: number;
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
}: IPost) => {
  return (
    <Link to={`/p/${1}`}>
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
            <img
              className=" rounded-full h-10"
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
            <div className="flex justify-around mt-2 ">
              <p>
                <InsertCommentIcon /> {comments}
              </p>
              <p>
                <ReplayIcon /> {quotes}
              </p>
              <p>
                <FavoriteBorderIcon /> {likes}
              </p>
            </div>
          </div>
        </div>
      </div>
    </Link>
  );
};

export default Posts;
