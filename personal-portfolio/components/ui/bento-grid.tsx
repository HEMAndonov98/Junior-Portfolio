import { cn } from "@/lib/utils";
import { BackgroundGradientAnimation } from "./background-gradient-animation";
import { GlobeDemo } from "../GridGlobe";
import EmailCard from "../EmailCard";
import { useRouter } from "next/router";

export const BentoGrid = ({
  className,
  children,
}: {
  className?: string;
  children?: React.ReactNode;
}) => {
  return (
    <div
      className={cn(
        "grid grid-cols-1 md:grid-cols-6 lg:grid-cols-5 md:grid-row-7 gap-4 lg:gap-8 mx-auto",
        className
      )}
    >
      {children}
    </div>
  );
};

export const BentoGridItem = ({
  className,
  title,
  description,
  id,
  img,
  imgClassName,
  spareImg,
  titleClassName
}:
  {
    className?: string;
    title?: string | React.ReactNode;
    description?: string | React.ReactNode;
    header?: React.ReactNode;
    icon?: React.ReactNode;
    id: number;
    img?: string;
    imgClassName?: string;
    spareImg?: string;
    titleClassName?: string;
  }) => {

  const router = useRouter();
  const basePath = router.basePath;

  return (
    <div
      className={cn(
        "row-span-1 relative overflow-hidden rounded-3xl group/bento hover:shadow-xl transition duration-200 shadow-input dark:shadow-none border border-white/[0.1] justify-between flex flex-col space-y-2",
        className
      )}
      style={
        {
          background: "rgb(0,3,25)",
          backgroundColor: "linear-gradient(90deg, rgba(0,3,25,1) 21%, rgba(55,55,208,1) 58%, rgba(2,8,9,1) 100%)",
        }
      }
    >
      <div className={`${id === 6 && 'flex justify-center'} h-full`}>
        <div className="w-full h-full absolute">
          {img && (
            <img
              src={basePath.img}
              alt={img}
              className={cn(imgClassName, 'object-cover object-center opacity-75')}
            />
          )}
        </div>
        <div className={`absolute right-0 -bottom-5 ${id === 5 && 'w-full opacity-80'}`}>
          {spareImg && (
            <img
              src={spareImg}
              alt={spareImg}
              className='object-cover object-center'
            />
          )}
        </div>
        {id === 6 && (
          <BackgroundGradientAnimation>
            <div className="absolute z-50 flex justify-center items-center text-white font-bold" />
          </BackgroundGradientAnimation>
        )}

        <div className={cn(titleClassName, "relative group-hover/bento:translate-x-2 transition duration-200 md:h-full min-h-40 px-5 p-5 lg:p-10 flex flex-col")}>
          <div className="font-sans font-extralight text-[#c1c2d3] text-sm md:text-xs lg:text-base z-10">
            {description}
          </div>
          <div className="font-sans font-bold text-lg lg:text-3xl max-w-96 z-10">
            {title}
          </div>
          {id === 2 && <GlobeDemo />}

          {id === 3 && (
            <div className="flex absolute gap-3 lg:gap-5 w-fit top-0 right-10 lg:right-3 z-0 opacity-85">
              <div className="flex flex-col gap-2 lg:gap-3">
                {['js', 'Node.js', 'Next.js', '.Net Core'].map
                  ((item) => (
                    <span key={item} className="py-2 lg:py-3 lg:px-3 px-3 text-xs lg:text-base opacity-50 lg:opacity-100 rounded-lg text-center bg-[#10132E]">{item}</span>
                  ))}
                <span className="py-3 px-3 roundend-lg text-center bg-[#10132e]" />
              </div>
              <div className="flex flex-col-reverse gap-2 lg:gap-5">
                {['ASP.NET', 'C#', 'EF-Core', 'MSSQL'].map
                  ((item) => (
                    <span key={item} className="py-2 lg:py-3 lg:px-3 px-3 text-xs lg:text-base opacity-50 lg:opacity-100 rounded-lg text-center bg-[#10132E]">{item}</span>
                  ))}
                <span className="py-3 px-3 roundend-lg text-center bg-[#10132e]" />
              </div>
            </div>
          )}

          {id === 6 && (
            <EmailCard />
          )}
        </div>
      </div>
    </div>

  );
};
