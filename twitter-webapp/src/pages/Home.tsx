import InputTweet from "../components/InputTweet";

const Home = () => {
  return (
    <div>
      <h1 className="font-bold text-lg">Home</h1>
      <div className="flex w-[100%]">
        <div className="w-[50%] p-3 flex justify-center">
          <h3 className="font-semibold">For you</h3>
        </div>
        <div className="w-[50%] p-3 flex justify-center">
          <h3 className="text-gray-500 font-semibold">Following</h3>
        </div>
      </div>
      <div className="w-[100%] p-3">
        <InputTweet />
      </div>
      <div className="mt-10">
        <div className="flex gap-3">
          <div className="w-[8%]">
            <img
              className=" rounded-full h-10"
              src="https://www.spongebobshop.com/cdn/shop/products/SB-Standees-Spong-3_800x.jpg?v=1603744568"
            />
          </div>
          <div className="">
            <h5 className="font-semibold">
              Lance <a className="text-gray-500 font-medium">@Lance123</a>
            </h5>
            <p>
              Arda Güler has suffered a meniscus injury and will be out for the
              upcoming months, Real Madrid report. Get well soon, Arda 🤍🙏
            </p>
            <img
              className=" rounded-xl mt-4 max-h-[60vh]"
              src="https://ichef.bbci.co.uk/images/ic/640x360/p0fqd2bp.jpg"
            />
          </div>
        </div>
      </div>
    </div>
  );
};

export default Home;
