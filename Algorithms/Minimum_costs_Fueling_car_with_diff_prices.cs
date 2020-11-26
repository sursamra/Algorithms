namespace Algorithms
{
    class Minimum_costs_Fueling_car_with_diff_prices
    {
        /*
         * You and your friends are driving to Tijuana for springbreak. You are saving your money for the trip and so
         * you want to minimize the cost of gas on the way. In order to minimize your gas costs you and your friends 
         * have compiled the following information. First your car can reliably travel m miles on a tank of gas 
         * (but no further). One of your friends has mined gas-station data off the web and has plotted every gas 
         * station along your route along with the price of gas at that gas station. Speciﬁcally they have created 
         * a list of n+1 gas station prices from closest to furthest and a list of n distances between two adjacent
         * gas stations. Tacoma is gas station number 0 and Tijuana is gas station number n. For convenience they 
         * have converted the cost of gas into price per mile traveled in your car. In addition the distance in miles
         * between two adjacent gas-stations has also been calculated. You will begin your journey with a full tank of 
         * gas and when you get to Tijuana you will ﬁll up for the return trip. You need to determine which gas stations
         * to stop at to minimize the cost of gas on your trip.

Sample Input:

Prices (cents per mile) [12,14,21,14,17,22,11,16,17,12,30,25,27,24,22,15,24,23,15,21]

Distances (miles) [31,42,31,33,12,34,55,25,34,64,24,13,52,33,23,64,43,25,15]

Your car can travel 170 miles on a tank of gas.

        Answer

        refill 31 miles at station 1 for 14 cents/mi, refill 152 miles at station 6 for 11 cents/mi, refill 114 miles at station 9 for 12 cents/mi,
        refill 88 miles at station 11 for 25 cents/mi, refill 121 miles at station 15 for 15 cents/mi, and finally arrive at station 19

        total cost is (31 * 14) + (152 * 11) + (114 * 12) + (88 * 25) + (121 * 15) = 7489 cents. and I assumed that we don't need to count the cost of a full tank
        (which is 170 * 12) at station 0 (the starting point)
         */
        public static void Test()
        {
            Logger.Init("Minimum_cost_diff_fueling_prices");
            int[] price = { 12, 14, 21, 14, 17, 22, 11, 16, 17, 12, 30, 25, 27, 24, 22, 15, 24, 23, 15, 21 }; //total 20 stations

            int[] distance = { 31, 42, 31, 33, 12, 34, 55, 25, 34, 64, 24, 13, 52, 33, 23, 64, 43, 25, 15 };  //total 19 distances      
            Logger.Log(0, "prices");
            Logger.Log(1, price);
            Logger.Log(0, "distance");
            Logger.Log(1, distance);

            int N = 19;
            int[] cost = new int[N];
            int[] parent = new int[N]; //for backtracking

            cost[0] = 0; //base case (assume that we don't need to fill gas on station 0)

            int i, j, dist;
            int maxroad = 170;

            for (i = 0; i < N; i++) //initialize backtracking array
                parent[i] = -1;


            for (i = 1; i <= N - 1; i++) //for every station from 1 to 18
            {
                Logger.Log(0, $"At station {i}");
                int priceval = price[i]; //get price of station i               
                int min = int.MaxValue;
                dist = 0;
                Logger.Log(1, $"Look for other stations backward from {i} and check for {i - 1} to 0");
                for (j = i - 1; j >= 0; j--) //for every station j within 170 away from station i
                {

                    dist += distance[j]; //distance[j] is distance from station j to station j+1
                    Logger.Log(2, $"Price and distance {priceval} and  {dist}  at  station {j} from station {i}");
                    if (dist > maxroad)
                    {
                        Logger.Log(3, $"Gone too far as dist > maxroad i.e. {dist} > {maxroad}");
                        break;
                    }

                    if ((cost[j] + priceval * dist) < min) //pick MIN value defined in recurrence relation                       
                    {
                        Logger.Log(2, $"cost[j] + priceval * dist < min i.e. {cost[j]} + {priceval} * {dist} < {min} i.e. {cost[j] + priceval * dist} < {min}");
                        Logger.Log(2, $" parent[i] = j i.e. parent at {i} replaced with {j} i.e. {parent[i]} = {j}");
                        min = cost[j] + priceval * dist;
                        parent[i] = j;
                    }
                    else
                    {
                        Logger.Log(3, $" Ignore as (cost[j] + priceval * dist) > min i.e. {(cost[j] + priceval * dist)} > {min}");
                    }

                }

                cost[i] = min;
                Logger.Log(3, $"cost[i] = min  i.e. cost at {i} should be replace with {min} i.e. {cost[i]} = {min}");
                Logger.Log(4, "cost array is >> ");
                Logger.Log(5, cost);
                Logger.Log(4, "parent array is >> ");
                Logger.Log(5, parent);

            }



            //after all costs from cost[1] up to cost[18] are found, we pick
            //minimum cost among the stations within 170 miles away from station 19
            //and show the stations we stopped at by backtracking from end to start

            int startback = N - 1;
            int answer = int.MaxValue;
            i = N - 1;
            dist = distance[i];
            Logger.Log(0, $"i {i} startback {startback} answer {startback} dist {dist} cost[i] {cost[i]} distance[i] {distance[i]} ");

            while (dist <= maxroad && i >= 0)
            {
                Logger.Log(1, $"i {i} startback {startback} answer {startback} dist {dist} cost[i] {cost[i]} distance[i] {distance[i]} ");
                if (cost[i] < answer)
                {
                    Logger.Log(2, $"cost[i] < answer {cost[i]} <{answer}");

                    answer = cost[i];
                    startback = i;
                    Logger.Log(2, $"so answer {answer} startback {startback}");
                }
                else
                    Logger.Log(2, $"Ignore as cost[i] > answer i.e. {cost[i]} > {answer}");

                i--;
                dist += distance[i];
            }
            Logger.Flush();
        }
    }
}
