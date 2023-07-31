import { explorePost } from "../config/data";
import Posts from "../components/Posts";

const Explore = () => {
  return (
    <div>
      <h1 className="font-bold text-3xl">Explore</h1>
      <hr className="mt-5" />
      <div className="mt-2">
        {explorePost.map((data) => (
          <Posts
            profileImg={data.profileImg}
            desc={data.desc}
            postImg={data.postImg}
            name={data.name}
            username={data.username}
          />
        ))}
      </div>
    </div>
  );
};

export default Explore;
