```cpp
#include <algorithm>
#include <iostream>
#include <vector>

struct Edge {
    int u, v, weight;
    bool operator<(Edge const& other) {
        return weight < other.weight;
    }
};

std::vector<int> parent, rank;

void make_set(int v) {
    parent[v] = v;
    rank[v] = 0;
}

int find_set(int v) {
    if (v == parent[v])
        return v;
    return parent[v] = find_set(parent[v]);
}

void union_sets(int a, int b) {
    a = find_set(a);
    b = find_set(b);
    if (a != b) {
        if (rank[a] < rank[b])
            std::swap(a, b);
        parent[b] = a;
        if (rank[a] == rank[b])
            rank[a]++;
    }
}

int main() {
    int n;
    std::cin >> n;
    std::vector<Edge> edges;
    parent.resize(n);
    rank.resize(n);
    for (int i = 0; i < n; i++)
        make_set(i);

    int cost = 0;
    std::vector<Edge> result;
    std::sort(edges.begin(), edges.end());

    for (Edge e : edges) {
        if (find_set(e.u) != find_set(e.v)) {
            cost += e.weight;
            result.push_back(e);
            union_sets(e.u, e.v);
        }
    }

    std::cout << cost << std::endl;
    for (Edge e : result) {
        std::cout << e.u << " " << e.v << std::endl;
    }

    return 0;
}
```