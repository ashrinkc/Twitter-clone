import History from "./History";
import SearchInput from "./SearchInput";

const RightBox = () => {
  return (
    <div className="flex flex-col gap-5">
      <SearchInput />
      <History />
    </div>
  );
};

export default RightBox;
