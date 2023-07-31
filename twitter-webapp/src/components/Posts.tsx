import InsertCommentIcon from "@mui/icons-material/InsertComment";
import ReplayIcon from "@mui/icons-material/Replay";
import FavoriteBorderIcon from "@mui/icons-material/FavoriteBorder";

export interface IPost {
  profileImg?: string;
  name: string;
  username: string;
  desc?: string;
  postImg?: string;
}
const Posts = ({ profileImg, name, username, desc, postImg }: IPost) => {
  return (
    <div className="hover:bg-gray-100 p-4">
      <div className="flex gap-3">
        <div className="w-[8%]">
          <img className=" rounded-full h-10" src={profileImg} />
        </div>
        <div className="w-[100%]">
          <h5 className="font-semibold">
            {name} <a className="text-gray-500 font-medium">{username}</a>
          </h5>
          <p>{desc}</p>
          <img className=" rounded-xl mt-4 max-h-[60vh]" src={postImg} />
          <div className="flex justify-around mt-2 ">
            <p>
              <InsertCommentIcon /> 0
            </p>
            <p>
              <ReplayIcon /> 0
            </p>
            <p>
              <FavoriteBorderIcon /> 0
            </p>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Posts;
