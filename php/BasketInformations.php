<?php

/**
 * Created by Shodo on 16/04/2025.
 * This class is a basket
 */
class BasketInformations
{
    // The product of the basket
    private static array $map = [];

    public function addProductToBasket(string $product, int $price): void
    {
        self::$map[$product] = $price;
    }

    public function getBasketPrice(bool $inCents): int
    {
        $v = array_sum(self::$map);
        return $inCents ? $v * 100 : $v;
    }

    public function resetBasket(): void
    {
        $this->buyBasket();
    }

    public function buyBasket(): void
    {
        self::$map = [];
    }

    public function isBasketContains(string $product): bool
    {
        return array_key_exists($product, self::$map);
    }

    public function mixWithBasket(BasketInformations $b): void
    {
        self::$map = array_merge(self::$map, $b->getMap());
    }

    private function getMap(): array
    {
        return self::$map;
    }
}