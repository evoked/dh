import { useContext, useEffect, useState } from "react";
import { Pie } from "react-chartjs-2";
import { Chart as ChartJS, ArcElement, Tooltip, Legend } from "chart.js";
import { ProductContext } from "../../services/Context/product-context";
import { mapCategoryFromNumber } from "../../types/MapCategory";

ChartJS.register(ArcElement, Tooltip, Legend);

const categoryIds = [0, 1, 2, 3, 4];

export default function PieChart() {
  const { products } = useContext(ProductContext);
  const [categoryCounts, setCategoryCounts] = useState<number[]>([0, 0, 0, 0, 0]);

  useEffect(() => {
    const counts = [0, 0, 0, 0, 0];
    products.forEach((product) => {
      if (
        typeof product.category === "number" &&
        product.category >= 0 &&
        product.category < counts.length
      ) {
        counts[product.category] += product.stockQuantity;
      }
    });
    setCategoryCounts(counts);
  }, [products]);

  const data = {
    labels: categoryIds.map((id) => mapCategoryFromNumber(id)),
    datasets: [
      {
        label: "# of Products",
        data: categoryCounts,
        backgroundColor: [
          "rgba(255, 99, 132, 0.5)",
          "rgba(54, 162, 235, 0.5)",
          "rgba(255, 206, 86, 0.5)",
          "rgba(75, 192, 192, 0.5)",
          "rgba(153, 102, 255, 0.5)"
        ],
        borderColor: [
          "rgba(255, 99, 132, 1)",
          "rgba(54, 162, 235, 1)",
          "rgba(255, 206, 86, 1)",
          "rgba(75, 192, 192, 1)",
          "rgba(153, 102, 255, 1)"
        ],
        borderWidth: 1,
      },
    ],
  };

  return (
    <div style={{ maxWidth: 400, margin: "0 auto" }}>
      <Pie data={data}  />
    </div>
  );
}
